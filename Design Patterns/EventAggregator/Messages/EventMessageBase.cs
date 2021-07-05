namespace EventAggregator.Messages
{
    public abstract class EventMessageBase
    {
        public object Sender { get; set; }
        public EventMessageBase(object sender) => Sender = sender;
    }
}
