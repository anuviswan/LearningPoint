using Ocelot.Configuration;
using Ocelot.Logging;
using Ocelot.Provider.Polly;
using Polly;
using Polly.CircuitBreaker;
using System.Net;

namespace OcelotDemo.Api
{
    public class PollyWithInternalServerErrorCircuitBreakingDelegratingHandler: PollyCircuitBreakingDelegatingHandler
    {
        private QoSOptions _options;
        private readonly IOcelotLogger _logger;
        private readonly AsyncCircuitBreakerPolicy<HttpResponseMessage> _responsePolicy;

        public PollyWithInternalServerErrorCircuitBreakingDelegratingHandler(DownstreamRoute route, IOcelotLoggerFactory loggerFactory):base(new PollyQoSProvider(route,loggerFactory),loggerFactory)
        {
            _options = route.QosOptions;
            _logger = loggerFactory.CreateLogger<PollyWithInternalServerErrorCircuitBreakingDelegratingHandler>();

            _responsePolicy = Policy.HandleResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.InternalServerError)
                                      .CircuitBreakerAsync(_options.ExceptionsAllowedBeforeBreaking, TimeSpan.FromMilliseconds(_options.DurationOfBreak));

        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                return await _responsePolicy.ExecuteAsync(() => base.SendAsync(request, cancellationToken));
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
