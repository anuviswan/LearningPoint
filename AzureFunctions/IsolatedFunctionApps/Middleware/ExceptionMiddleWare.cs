using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Logging;

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
                var logger = context.GetLogger(context.FunctionDefinition.Name);
                logger.LogError("Unexpected Error in {0}: {1}",context.FunctionDefinition.Name,ex.Message);
            }
        }

    }
}
