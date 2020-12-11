using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AzureFunc.Crud.MemoryCollection
{
    public static class CrudInMemory
    {
        private static Dictionary<string, CrudItem> _inMemoryStorage = new Dictionary<string, CrudItem>();
        [FunctionName("Crud")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous,  "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<Request<CrudItem>>(requestBody);

            switch (data.Mode)
            {
                case "Add":
                    var id = Guid.NewGuid();
                    _inMemoryStorage.Add(id.ToString(), data.Record);
                    return new OkObjectResult(data.Record);
                case "Get":
                    if (_inMemoryStorage.ContainsKey(data.Key))
                    {
                        return new OkObjectResult(_inMemoryStorage[data.Key]);
                    }
                    return new BadRequestObjectResult("Data not found");
                default:
                    return new BadRequestObjectResult("Invalid mode");
            }


        }
    }

    public class Request<T>
    {
        public string Key { get; set; }
        public string Mode { get; set; }
        public T Record { get; set; }
    }

    public class CrudItem
    {
        public string FName { get; set; }
        public string LName { get; set; }
    }
}
