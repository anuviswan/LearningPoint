using Ocelot.Configuration;
using Ocelot.Logging;
using Ocelot.Provider.Polly;
using Polly;
using Polly.CircuitBreaker;
using System.Net;

namespace OcelotDemo.Api
{
    public class PollyWithInternalServerErrorCircuitBreakingDelegatingHandler:DelegatingHandler
    {
        private readonly IOcelotLogger _logger;
        private Polly.Wrap.AsyncPolicyWrap<HttpResponseMessage> _circuitBreakerPolicies;
        public PollyWithInternalServerErrorCircuitBreakingDelegatingHandler(DownstreamRoute route, IOcelotLoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PollyWithInternalServerErrorCircuitBreakingDelegatingHandler>();

            var pollyQosProvider = new PollyQoSProvider(route,loggerFactory);
            
            var responsePolicy = Policy.HandleResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.InternalServerError)
                                      .CircuitBreakerAsync(route.QosOptions.ExceptionsAllowedBeforeBreaking, 
                                                            TimeSpan.FromMilliseconds(route.QosOptions.DurationOfBreak));
            _circuitBreakerPolicies  = Policy.WrapAsync(pollyQosProvider.CircuitBreaker.Policies)
                                             .WrapAsync(responsePolicy);
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                return await _circuitBreakerPolicies.ExecuteAsync(() => base.SendAsync(request, cancellationToken));
            }
            catch (BrokenCircuitException ex)
            {
                _logger.LogError($"Reached to allowed number of exceptions. Circuit is open", ex);
                throw;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Error in CircuitBreakingDelegatingHandler.SendAync", ex);
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
