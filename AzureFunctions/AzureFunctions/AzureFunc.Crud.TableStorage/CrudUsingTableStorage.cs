using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
//using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.Azure.Cosmos.Table;
using System.Collections.Generic;
using System.Linq;

namespace AzureFunc.Crud.TableStorage
{
    public static class CrudUsingTableStorage
    {
        [FunctionName("TodoAdd")]
        public static async Task<IActionResult> Add(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, 
            [Table("todos","Key","Key",Take =1)] TodoKey keyGen,
            [Table("todos")] CloudTable todoTable,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<TodoDto>(requestBody);

            if (keyGen == null)
            {
                keyGen = new TodoKey
                {
                    Key = 1000,
                    PartitionKey = "Key",
                    RowKey = "Key"
                };

                var addKeyOperation = TableOperation.Insert(keyGen);
                await todoTable.ExecuteAsync(addKeyOperation);
            }

            var rowKey = keyGen.Key;

            var dataToInsert = new TodoTableEntity
            {
                Title = data.Title,
                Description = data.Description,
                IsCompleted = data.IsCompletd,
                PartitionKey = data.Title[0].ToString(),
                RowKey = keyGen.Key.ToString()
            };

            keyGen.Key += 1;
            var updateKeyOperation = TableOperation.Replace(keyGen);
            await todoTable.ExecuteAsync(updateKeyOperation);
            var addEntryOperation = TableOperation.Insert(dataToInsert);
            todoTable.CreateIfNotExists();
            await todoTable.ExecuteAsync(addEntryOperation);

            return new OkObjectResult(keyGen.Key);
        }


        [FunctionName("TodoGetAll")]
        public static async Task<IActionResult> GetAll(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [Table("todos")] CloudTable todoTable,
            ILogger log)
        {
            var tableQuery = new TableQuery<TodoTableEntity>();
            tableQuery.SelectColumns = new List<string> { nameof(TodoTableEntity.Description) };
            tableQuery.FilterString = TableQuery.GenerateFilterCondition(nameof(TableEntity.PartitionKey), QueryComparisons.NotEqual, "Key");

            var result = todoTable.ExecuteQuery(tableQuery);
            return new OkObjectResult(result);
        }

        [FunctionName("TodoGetOne")]
        public static async Task<IActionResult> GetOne(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
        [Table("todos")] CloudTable todoTable,
        ILogger log)
        {
            string id = req.Query["id"];

            var tableQuery = new TableQuery<TodoTableEntity>();
            tableQuery.SelectColumns = new List<string> { nameof(TodoTableEntity.Description) };

            tableQuery.FilterString = TableQuery.CombineFilters(
                TableQuery.GenerateFilterCondition(nameof(TableEntity.PartitionKey), QueryComparisons.NotEqual, "Key"), 
                TableOperators.And, 
                TableQuery.GenerateFilterCondition(nameof(TableEntity.RowKey), QueryComparisons.Equal, id));

            var result = todoTable.ExecuteQuery(tableQuery);
            return new OkObjectResult(result);
        }


        [FunctionName("TodoGetOneBinding")]
        public static async Task<IActionResult> TodoGetOneBinding1(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "TodoGetOneBinding/{partition}/{id}")] HttpRequest req,
        [Table("todos", "{partition}", "{id}")] TodoTableEntity todo,
        ILogger log)
        {
            return new OkObjectResult(todo);
        }


        private static async Task<IEnumerable<T>> GetEntitiesFromTable<T>(CloudTable table) where T : ITableEntity, new()
        {
            TableQuerySegment<T> querySegment = null;
            var entities = new List<T>();
            var query = new TableQuery<T>();

            do
            {
                querySegment = await table.ExecuteQuerySegmentedAsync(query, querySegment?.ContinuationToken);
                entities.AddRange(querySegment.Results);
            } while (querySegment.ContinuationToken != null);

            return entities;
        }


        [FunctionName("Update")]
        public static async Task<IActionResult> Update(
            [HttpTrigger(AuthorizationLevel.Anonymous,"post",Route = null)] HttpRequest request,
            [Table("todos")]CloudTable todoTable,
            ILogger log)
        {
            log.LogInformation("Request to update Record");

            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<TodoDto>(requestBody);

            var rowKeyToUpdate= request.Query[nameof(TableEntity.RowKey)];
            var partitionKeyToUpdate= request.Query[nameof(TableEntity.PartitionKey)];

            var tableEntity = new TodoTableEntity
            {
                RowKey = rowKeyToUpdate,
                PartitionKey = partitionKeyToUpdate,
                Title = data.Title,
                Description = data.Description,
                IsCompleted = data.IsCompletd,
                ETag = "*"
            };

            var updateOperation = TableOperation.Replace(tableEntity);

            var result = await todoTable.ExecuteAsync(updateOperation);
            return new OkObjectResult(result);
        }

        [FunctionName("UpdateUsingBinding")]
        public static async Task<IActionResult> UpdateUsingBinding(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "UpdateUsingBinding/{partitionKey}/{rowKey}")] HttpRequest request,
        [Table("todos", "{partitionKey}", "{rowKey}")] TodoTableEntity tableEntity,
        [Table("todos")] CloudTable todoTable,
         ILogger log)
        {
            log.LogInformation("Request to update Record");

            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<TodoDto>(requestBody);

            tableEntity.Title = data.Title;
            tableEntity.Description = data.Description;
            tableEntity.IsCompleted = data.IsCompletd;

            var updateOperation = TableOperation.Replace(tableEntity);
            var result = await todoTable.ExecuteAsync(updateOperation);
            return new OkObjectResult(result);
        }


        [FunctionName("UpdateWithRetrival")]
        public static async Task<IActionResult> UpdateWithRetrival(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest request,
        [Table("todos")] CloudTable todoTable,
         ILogger log)
        {
            log.LogInformation("Request to update Record");

            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<TodoDto>(requestBody);

            var tableQuery = new TableQuery<TodoTableEntity>();

            tableQuery.FilterString = TableQuery.CombineFilters(
                TableQuery.GenerateFilterCondition(nameof(TableEntity.PartitionKey), QueryComparisons.NotEqual, "Key"),
                TableOperators.And,
                TableQuery.GenerateFilterCondition(nameof(TodoTableEntity.Title), QueryComparisons.Equal, data.Title));
            var result = todoTable.ExecuteQuery(tableQuery);

            var itemToUpdate = result.First();
            itemToUpdate.Description = data.Description;
            itemToUpdate.IsCompleted = data.IsCompletd;

            var updateOperation = TableOperation.Replace(itemToUpdate);
            var updateResponse = await todoTable.ExecuteAsync(updateOperation);
            return new OkObjectResult(updateResponse);
        }

        [FunctionName("DeleteRecord")]
        public static async Task<IActionResult> DeleteEntity(
            [HttpTrigger(AuthorizationLevel.Anonymous,"POST", Route = "DeleteRecord/{partitionKey}/{rowKey}")] HttpRequest request,
            [Table("todos", "{partitionKey}", "{rowKey}")] TodoTableEntity tableEntity,
            [Table("todos")] CloudTable todoTable,
            ILogger log)
        {
            log.LogInformation("Request to delete the record");

            var deleteOperation = TableOperation.Delete(tableEntity);
            var result = await todoTable.ExecuteAsync(deleteOperation);
            return new OkObjectResult(result);
        }

        [FunctionName("DeleteWithoutBinding")]
        public static async Task<IActionResult> DeleteWithoutBinding(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest request,
        [Table("todos")] CloudTable todoTable,
         ILogger log)
        {
            log.LogInformation("Request to delete Record without binding");

            string partitionKey = request.Query["pkey"];
            string rowKey = request.Query["rkey"];

            var tableQuery = new TableQuery<TodoTableEntity>();

            var filterRowKeyAndPartitionKey = TableQuery.CombineFilters(
                TableQuery.GenerateFilterCondition(nameof(TodoTableEntity.RowKey), QueryComparisons.Equal, rowKey),
                TableOperators.And,
                TableQuery.GenerateFilterCondition(nameof(TodoTableEntity.PartitionKey), QueryComparisons.Equal, partitionKey));

            tableQuery.FilterString = TableQuery.CombineFilters(
                TableQuery.GenerateFilterCondition(nameof(TableEntity.PartitionKey), QueryComparisons.NotEqual, "Key"),
                TableOperators.And,
                filterRowKeyAndPartitionKey);

            var itemToDelete = todoTable.ExecuteQuery(tableQuery).First();

            var deleteOperation = TableOperation.Delete(itemToDelete);
            var deleteResponse = await todoTable.ExecuteAsync(deleteOperation);
            return new OkObjectResult(deleteResponse);
        }

    }
    





public class TodoKey:TableEntity
{
    public int Key { get; set; }
}

public class TodoDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompletd { get; set; }
}

public class TodoTableEntity : TableEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}
}
