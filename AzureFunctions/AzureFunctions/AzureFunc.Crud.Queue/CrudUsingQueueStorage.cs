using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Storage.Queue;
using Newtonsoft.Json;
using System.Text;
using System;

namespace AzureFunc.Crud.Queue
{
    public static class CrudUsingQueueStorage
    {
        [FunctionName("AddMessageToQueue")]
        public static async Task<IActionResult> AddMessageToQueue(
           [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest request,
           [Queue("SampleQueue")] CloudQueue cloudQueue)
        {
            var message = request.Query["item"];

            var queueMessage = new CloudQueueMessage(message);
            await cloudQueue.AddMessageAsync(queueMessage);
            return new OkObjectResult($"Message :(`{message}`) added to tbe queue");
        }

        [FunctionName("PopMessageFromQueue")]
        public static async Task<IActionResult> PopMessageFromQueue(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest request,
        [Queue("SampleQueue")] CloudQueue cloudQueue)
        {
            var message = await cloudQueue.PeekMessageAsync();
            await cloudQueue.DeleteIfExistsAsync();

            return new OkObjectResult(message == null ? "No Message found to be removed":$"Message :(`{message.AsString}`) has been removed");
        }

        [FunctionName("NumberOfItemsInQueue")]
        public static async Task<IActionResult> NumberOfItemsInQueue(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest request,
            [Queue("SampleQueue")] CloudQueue cloudQueue)
        {
            await cloudQueue.FetchAttributesAsync();
            return new OkObjectResult($"Approx. number of Items in Queue :{cloudQueue.ApproximateMessageCount}");
        }

        [FunctionName("RestoreFromPoisonQueue")]
        public static async Task<IActionResult> RestoreFromPoisonQueue(
            [HttpTrigger(AuthorizationLevel.Anonymous,"get",Route =null)] HttpRequest request,
            [Queue("SampleQueue")] CloudQueue cloudQueue,
            [Queue("SampleQueue-Poison")]CloudQueue poisonQueue)
        {
            var message = await poisonQueue.PeekMessageAsync();
            var count = 0;
            while (message != null)
            {
                count++;
                await poisonQueue.DeleteMessageAsync(message);
                await cloudQueue.AddMessageAsync(message);
                
                message = await cloudQueue.PeekMessageAsync();
            }

            return new OkObjectResult($"Number of Messages restored :{count}");
        }


        //[FunctionName("AddOnQueueTrigger")]
        //public static async Task AddOnQueueTrigger(
        //  [QueueTrigger("SampleQueue")] string message,
        //  [Queue("BackupQueue")] CloudQueue cloudQueue)
        //{
        //    var queueMessage = new CloudQueueMessage(message);
        //    await cloudQueue.AddMessageAsync(queueMessage);
        //}


        [FunctionName("GetItemFromQueue")]
        public static async Task<IActionResult> GetItemFromQueue(
   [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest request,
   [Queue("SampleQueue")] CloudQueue cloudQueue)
        {
            var canDequeue = request.Query.ContainsKey("dequeue");

            var message = await cloudQueue.GetMessageAsync();
            if (canDequeue)
            {
                await cloudQueue.DeleteMessageAsync(message);
            }

            if (message == null)
                return new OkObjectResult("No item in the queue");

            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Message : `{message.AsString}`");
            resultBuilder.AppendLine($"Pop Reciept : {message.PopReceipt}");
            resultBuilder.AppendLine($"Dequeue Count : {message.DequeueCount}");
            resultBuilder.AppendLine($"Insertion Time: {message.InsertionTime}");
            resultBuilder.AppendLine($"Next Visible Time: {message.NextVisibleTime}");
            return new OkObjectResult($"Data Retrivied :{resultBuilder.ToString()}");
        }


        [FunctionName("PeekItemFromQueue")]
        public static async Task<IActionResult> PeekItemFromQueue(
   [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest request,
   [Queue("SampleQueue")] CloudQueue cloudQueue)
        {

            var message = await cloudQueue.PeekMessageAsync();
            

            if (message == null)
                return new OkObjectResult("No item in the queue");

            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Message : `({message.AsString})`");
            resultBuilder.AppendLine($"Pop Reciept : {message.PopReceipt}");
            resultBuilder.AppendLine($"Dequeue Count : {message.DequeueCount}");
            resultBuilder.AppendLine($"Insertion Time: {message.InsertionTime}");
            resultBuilder.AppendLine($"Next Visible Time: {message.NextVisibleTime}");
            return new OkObjectResult($"Data Retrivied :{resultBuilder.ToString()}");
        }


        [FunctionName("MultioutputSample")]
        public static IActionResult MultiOutputDemo([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log,[Queue("SampleQueue")]out string queueOutput)
        {

            queueOutput = "New Activity detected";
            return new OkObjectResult($"Hello, Welcome to Isolated functions demo.");
        }
    }
}

