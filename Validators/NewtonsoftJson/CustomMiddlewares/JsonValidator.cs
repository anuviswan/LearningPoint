using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NewtonsoftJson.CustomMiddlewares
{
    public class JsonValidator
    {
        private readonly RequestDelegate _nextRequestDelegate;
        private readonly JSchema _schema;
        public JsonValidator(RequestDelegate next, string schemaPath)
        {
            (_nextRequestDelegate, _schema) = (next, JSchema.Parse(File.ReadAllText(schemaPath)));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request.Method == HttpMethods.Post)
            {
                context.Request.EnableBuffering();

                using var reader = new StreamReader(context.Request.Body);

                var body = await reader.ReadToEndAsync();
                context.Request.Body.Position = 0;

                var jsonBody = JObject.Parse(body);

                if(jsonBody.IsValid(_schema, out IList<string> errors) is false)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid request: " + string.Join(", ", errors));
                    return;
                }
            }

            await _nextRequestDelegate(context);
        }
        
    }
}
