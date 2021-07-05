namespace EventAggregator.Messages
{
    public class UserSaysHelloMessage : EventMessageBase
    {
        public UserSaysHelloMessage(object sender,string message):base(sender)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
