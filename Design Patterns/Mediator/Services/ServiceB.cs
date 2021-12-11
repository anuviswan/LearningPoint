namespace Mediator.Services;
public class ServiceB : ServiceBase
{
    public void SendMessage(string message)
    {
        _mediator.SendMessage(message, this);
    }

    public void DoOperationOne()
    {
        Console.WriteLine($"{nameof(ServiceB)}.{nameof(DoOperationOne)}");
    }

    public void DoOperationTwo()
    {
        Console.WriteLine($"{nameof(ServiceB)}.{nameof(DoOperationTwo)}");
    }
}
