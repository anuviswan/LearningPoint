using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Middleware;

namespace IsolatedFunctionApps.Middleware
{
    public class ExceptionMiddleWare : IFunctionsWorkerMiddleware
    {
        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            try
            {
                await next(context);                
            }
            catch(Exception ex)
            {
                v/*ar g = context.FunctionDefinition.Parameters.First(x => x.Type == typeof(HttpRequestData));*/
            }
        }

    }
}
