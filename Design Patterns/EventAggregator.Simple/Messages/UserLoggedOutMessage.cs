namespace EventAggregator.Simple.Messages
{
    public class UserLoggedOutMessage:MessageBase
    {
        public UserLoggedOutMessage(string userName, object sender):base(sender)
        {
            UserName = userName;
        }
    public string UserName { get; set; }
}
}
