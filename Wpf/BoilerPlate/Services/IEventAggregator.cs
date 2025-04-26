namespace BoilerPlate.Services
{
    public interface IEventAggregator
    {
        void Subscribe(object subscriber);
        void Unsubscribe(object subscriber);
        void PublishMessage(object message);
    }
}
