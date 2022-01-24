using Ocelot.Configuration;
using Ocelot.Logging;
using Ocelot.Provider.Polly;
using Polly;
using Polly.CircuitBreaker;
using System.Net;

namespace OcelotDemo.Api
{
    public class PollyWithInternalServerErrorCircuitBreakingDelegratingHandler:DelegatingHandler
    {
        private QoSOptions _options;
        private readonly IOcelotLogger _logger;
        private readonly AsyncCircuitBreakerPolicy<HttpResponseMessage> _responsePolicy;
        private Polly.Wrap.AsyncPolicyWrap<HttpResponseMessage> _circuitBreakerPolicies;
        public PollyWithInternalServerErrorCircuitBreakingDelegratingHandler(DownstreamRoute route, IOcelotLoggerFactory loggerFactory)
        {
            _options = route.QosOptions;
            _logger = loggerFactory.CreateLogger<PollyWithInternalServerErrorCircuitBreakingDelegratingHandler>();

            var pollyQosProvider = new PollyQoSProvider(route,loggerFactory);
            
            _responsePolicy = Policy.HandleResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.InternalServerError)
                                      .CircuitBreakerAsync(_options.ExceptionsAllowedBeforeBreaking, TimeSpan.FromMilliseconds(_options.DurationOfBreak));
            _circuitBreakerPolicies  = Policy.WrapAsync(pollyQosProvider.CircuitBreaker.Policies)
                                             .WrapAsync(_responsePolicy);
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
