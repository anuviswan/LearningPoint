using Mediator.Mediator;

namespace Mediator.Services;
public class ServiceA : ServiceBase
{

    public void RaiseNotification(string message)
    {
        _mediator.SendMessage(message, this);
    }

    public void DoOperationThree()
    {
        Console.WriteLine($"{nameof(ServiceA)}.{nameof(DoOperationThree)}");
    }

    public void DoOperationFour()
    {
        Console.WriteLine($"{nameof(ServiceA)}.{nameof(DoOperationFour)}");
    }
}
