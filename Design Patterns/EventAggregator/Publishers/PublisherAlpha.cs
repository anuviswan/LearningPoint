using EventAggregator.Messages;

namespace EventAggregator.Publishers
{
    public class PublisherAlpha
    {
        private IEventAggregator _aggregator;
        public PublisherAlpha(IEventAggregator eventAggregator)
        {
            _aggregator = eventAggregator;
        }

        public void PublishMessage(string message)
        {
            _aggregator.PublishMessage(new UserSaysHelloMessage(this,message));
        }
    }
}
