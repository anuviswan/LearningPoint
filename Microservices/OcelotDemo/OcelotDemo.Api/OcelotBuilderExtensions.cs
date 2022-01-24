using Ocelot.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Errors;
using Ocelot.Logging;
using Ocelot.Provider.Polly;
using Ocelot.Requester;
using Polly.CircuitBreaker;
using Polly.Timeout;

namespace OcelotDemo.Api
{
    public static class OcelotBuilderExtensions
    {
        public static IOcelotBuilder AddPollyWithInternalServerErrorHandling(this IOcelotBuilder builder)
        {
            var errorMapping = new Dictionary<Type, Func<Exception, Error>>
            {
                {typeof(TaskCanceledException), e => new RequestTimedOutError(e)},
                {typeof(TimeoutRejectedException), e => new RequestTimedOutError(e)},
                {typeof(BrokenCircuitException), e => new RequestTimedOutError(e)}
            };

            builder.Services.AddSingleton(errorMapping);

            DelegatingHandler QosDelegatingHandlerDelegate(DownstreamRoute route, IOcelotLoggerFactory logger)
            {
                return new PollyWithInternalServerErrorCircuitBreakingDelegatingHandler(route, logger);
            }

            builder.Services.AddSingleton((QosDelegatingHandlerDelegate)QosDelegatingHandlerDelegate);

            return builder;
        }
    }
}
