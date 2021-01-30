using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Storage.Blob;

namespace AzureFunc.Crud.Blob
{
    public static class CrudUsingBlobStorage
    {
        [FunctionName("AddItemBlockBlob")]
        public static async Task<IActionResult> AddItemBlockBlob(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [Blob("todos")] CloudBlobContainer blobContainer,
            ILogger log)
        {
            log.LogInformation("Request Recieved");

            await blobContainer.CreateIfNotExistsAsync();
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<TodoDto>(requestBody);

            if (string.IsNullOrEmpty(data.Id))
            {
                data.Id = Guid.NewGuid().ToString();
            }
            
            var serializedData = JsonConvert.SerializeObject(data);

            var blob = blobContainer.GetBlockBlobReference($"{data.Id}.json");
            await blob.UploadTextAsync(serializedData);
            return new OkObjectResult($"Item added to blob with Id = {data.Id}");
        }

        [FunctionName("UploadFileBlockBlob")]
        public static async Task<IActionResult> UploadFileBlockBlob(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [Blob("todos")] CloudBlobContainer blobContainer,
            ILogger log
            )
        {
            string key = req.Query["key"];
            var data = req.Form.Files["file"];
            using (var stream = data.OpenReadStream())
            {
                var blob = blobContainer.GetBlockBlobReference(key);
                await blob.UploadFromStreamAsync(stream);
            }
            return new OkObjectResult($"Item added to blob with Id = {key}");
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
