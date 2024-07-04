using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NewtonsoftJson.CustomMiddlewares
{
    public class JsonValidatorMiddleware
    {
        private readonly RequestDelegate _nextRequestDelegate;
        private readonly JSchema _schema;
        public JsonValidatorMiddleware(RequestDelegate next, string schemaPath)
        {
           
            (_nextRequestDelegate, _schema) = (next, JSchema.Parse(File.ReadAllText(schemaPath)));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request.Method == HttpMethods.Post)
            {
                context.Request.EnableBuffering();

                using (var reader = new StreamReader(context.Request.Body, leaveOpen:true))
                {
                    var body = await reader.ReadToEndAsync();
                    

                    var jsonBody = JObject.Parse(body);

                    if (jsonBody.IsValid(_schema, out IList<ValidationError> errors) is false)
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Invalid request: " + FormatErrors(errors));
                        return;

                    }
                    context.Request.Body.Position = 0;
                }

                
            }

            await _nextRequestDelegate(context);
        }

        private string FormatErrors(IList<ValidationError> errors)
        {
            List<string> errorMessages = new List<string>();
            foreach (var error in errors)
            {
                errorMessages.Add($"{error.Path}: {error.Message}");
            }
            return string.Join(", ", errorMessages);
        }

    }
}
