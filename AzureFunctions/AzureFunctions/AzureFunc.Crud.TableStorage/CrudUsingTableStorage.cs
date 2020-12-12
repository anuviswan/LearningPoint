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

namespace AzureFunc.Crud.TableStorage
{
    public static class CrudUsingTableStorage
    {
        [FunctionName("TodoAdd")]
        public static async Task<IActionResult> Add(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, 
            [Table("todos")] CloudTable todoTable,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<TodoDto>(requestBody);

            var dataToInsert = new TodoTableEntity
            {
                Title = data.Title,
                Description = data.Description,
                IsCompleted = data.IsCompletd,
                PartitionKey = data.Title[0].ToString(),
                RowKey = "sdsd"
            };


            var operation = TableOperation.Insert(dataToInsert);
            todoTable.CreateIfNotExists();
            await todoTable.ExecuteAsync(operation);

            return new OkObjectResult("Success");
        }
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
