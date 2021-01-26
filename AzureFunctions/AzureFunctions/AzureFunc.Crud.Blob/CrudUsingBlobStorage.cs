using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureFunc.Crud.Blob
{
    public static class CrudUsingBlobStorage
    {
        [FunctionName("AddItem")]
        public static async Task<IActionResult> AddItem(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [Blob("todos")] CloudBlobContainer blocContainer,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<TodoDto>(requestBody);

            data.Id = Guid.NewGuid().ToString();
            var serializedData = JsonConvert.SerializeObject(data);

            var blob = blocContainer.GetBlockBlobReference($"{data.Id}.json");
            await blob.UploadTextAsync(serializedData);
            return new OkObjectResult($"Item added to blob with Id = {data.Id}");
        }
    }

    public class TodoDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompletd { get; set; }
    }
}
