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
using System.Collections.Generic;

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
            [Blob("todos/{filename}", FileAccess.Write)] Stream fileStream,
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


            await blob.UploadFromByteArrayAsync(buffer, 0, buffer.Length);

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


        [FunctionName("DownloadBlockBlob")]
        public static async Task<IActionResult> DownloadBlockBlob(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [Blob("todos")] CloudBlobContainer blobContainer,
            ILogger log)
        {
            var key = req.Query["key"];

            var stream = new MemoryStream();
            var blob = await blobContainer.GetBlobReferenceFromServerAsync(key);
            await blob.DownloadToStreamAsync(stream);
            stream.Position = 0;
            return new FileStreamResult(stream, "application/octet-stream") { FileDownloadName = key };
        }


        [FunctionName("DownloadBlockBlobUsingBinding")]
        public static async Task<IActionResult> DownloadBlockBlobUsingBinding(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "DownloadBlockBlobUsingBinding/{fileName}")] HttpRequest req,
    [Blob("todos/{fileName}", FileAccess.Read)] Stream blob,
    string fileName,
    ILogger log)
        {
            var memoryStream = new MemoryStream();
            await blob.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            return new FileStreamResult(memoryStream, "application/octet-stream") { FileDownloadName = fileName };
        }


        [FunctionName("DownloadAppendBlob")]
        public static async Task<IActionResult> DownloadAppendBlob(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
    [Blob("sample")] CloudBlobContainer blobContainer,
    ILogger log)
        {

            var key = req.Query["key"];

            var stream = new MemoryStream();
            var blob = blobContainer.GetAppendBlobReference(key);
            await blob.DownloadToStreamAsync(stream);
            stream.Position = 0;
            return new FileStreamResult(stream, "text/plain") { FileDownloadName = key };
        }


        [FunctionName("DeleteFileBlockBlob")]
        public static async Task<IActionResult> DeleteFileBlockBlob(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [Blob("todos")] CloudBlobContainer blobContainer,
            ILogger log
            )
        {
            string key = req.Query["key"];

            var blob = blobContainer.GetBlockBlobReference(key);
            var result = await blob.DeleteIfExistsAsync();

            return new OkObjectResult($"Item Deletion {(result ? "Success" : "Failed")}");
        }


        [FunctionName("DeleteFileAppendBlob")]
        public static async Task<IActionResult> DeleteFileAppendBlob(
    [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
    [Blob("sample")] CloudBlobContainer blobContainer,
    ILogger log
    )
        {
            string key = req.Query["key"];

            var blob = blobContainer.GetAppendBlobReference(key);
            var result = await blob.DeleteIfExistsAsync();

            return new OkObjectResult($"Item Deletion {(result ? "Success" : "Failed")}");
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
