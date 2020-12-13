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

namespace AzureFunc.Crud.TableStorage
{
    public static class CrudUsingTableStorage
    {
        [FunctionName("TodoAdd")]
        public static async Task<IActionResult> Add(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, 
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
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [Table("todos", "Key", "Key", Take = 1)] TodoKey keyGen,
            [Table("todos")] CloudTable todoTable,
            ILogger log)
        {
            var tableQuery = new TableQuery<TodoTableEntity>();
            tableQuery.SelectColumns = new List<string> { nameof(TodoTableEntity.Description) };
            tableQuery.FilterString = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.NotEqual, "Key");

            var result = todoTable.ExecuteQuery(tableQuery);
            return new OkObjectResult(result);
        }

        [FunctionName("TodoGetOne")]
        public static async Task<IActionResult> GetOne(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
        [Table("todos", "Key", "Key", Take = 1)] TodoKey keyGen,
        [Table("todos")] CloudTable todoTable,
        ILogger log)
        {
            string id = req.Query["id"];

            var tableQuery = new TableQuery<TodoTableEntity>();
            tableQuery.SelectColumns = new List<string> { nameof(TodoTableEntity.Description) };

            //tableQuery.FilterString = TableQuery.CombineFilters(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.NotEqual, "Key"), TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, id), TableOperators.And);
            tableQuery.FilterString = TableQuery.CombineFilters(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.NotEqual, "Key"), TableOperators.And, TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, id));

            var result = todoTable.ExecuteQuery(tableQuery);
            return new OkObjectResult(result);
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
