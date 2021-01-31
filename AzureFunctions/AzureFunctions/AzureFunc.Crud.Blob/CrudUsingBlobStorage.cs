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
using System.Linq;

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

        [FunctionName("UploadFileBlockBlobBinding")]
        public static async Task<IActionResult> UploadFileBlockBlobBinding(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "UploadFileBlockBlobBinding/{filename}")] HttpRequest req,
            [Blob("todos/{filename}",FileAccess.Write)] Stream fileStream,
            string filename,
            ILogger log)
        {
            log.LogInformation("Request Recieved");
            var data = req.Form.Files["file"];
            var inputDataStream = data.OpenReadStream();
            await inputDataStream.CopyToAsync(fileStream);
            return new OkObjectResult($"Item added to blob with Id = {filename}");
        }


        [FunctionName("AddToAppendBlob")]
        public static async Task<IActionResult> AddToAppendBlob(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [Blob("sample")] CloudBlobContainer blobContainer,
            ILogger log)
        {
            log.LogInformation("Request Recieved");

            await blobContainer.CreateIfNotExistsAsync();
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<LogMessage>(requestBody);

            var blob = blobContainer.GetAppendBlobReference("applog.txt");

            
            if (!blob.Exists())
            {
                blob.CreateOrReplace();
            }
            await blob.AppendTextAsync($"User:{data.User}, Message:{data.Message}");
           
            return new OkObjectResult($"Item added to blob");
        }

        [FunctionName("AddToPageBlob")]
        public static async Task<IActionResult> AddToPageBlob(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [Blob("sample")] CloudBlobContainer blobContainer,
            ILogger log)
        {
            log.LogInformation("Request Recieved");

            await blobContainer.CreateIfNotExistsAsync();
           

            var blob = blobContainer.GetPageBlobReference("final.jpg");


            //if (!blob.Exists())
            //{
            //    await blob.CreateAsync(7168);
            //}

            await blob.CreateAsync(7168);
           
            var data = req.Form.Files["file"];
            var inputDataStream = data.OpenReadStream();
            byte[] buffer = GetBytes(inputDataStream);

            //Random rnd = new Random();

            //rnd.NextBytes(data);


            await blob.UploadFromByteArrayAsync(buffer,0,buffer.Length);

            return new OkObjectResult($"Item added to blob");
        }


        private static byte[] GetBytes(Stream input) 
        {
            byte[] buffer = new byte[7168];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }


    }

    public class LogMessage
    {
        public string Message { get; set; }
        public string User { get; set; }
    }

    public class TodoDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompletd { get; set; }
    }
}
