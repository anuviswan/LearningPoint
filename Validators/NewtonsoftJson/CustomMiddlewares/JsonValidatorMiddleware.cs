using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;


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

                    // Get the 'anyOf' schemas from the root schema
                    var anyOfSchemas = _schema.AnyOf.ToList();
                    var errors = new List<ValidationError>();
                    bool isValid = false;

                    foreach (var schema in anyOfSchemas)
                    {
                        // Validate the JSON payload against the schema
                        if (jsonBody.IsValid(schema, out IList<ValidationError> schemaErrors))
                        {
                            isValid = true;
                            break; // If any schema is valid, exit the loop
                        }
                        errors.AddRange(schemaErrors); // Collect errors from failed schemas
                    }

                    if (!isValid)
                    {
                        // Collect and format detailed errors
                        var errorMessages = errors
                            .Select(e => $"{e.Path}: {e.Message} (Schema Path: {e.Schema?.ToString() ?? "N/A"})")
                            .ToList();

                        // Output the errors
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Invalid request: " + string.Join(", ", errorMessages));
                        await context.Response.Body.FlushAsync();
                        //await context.Response.CompleteAsync();
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
