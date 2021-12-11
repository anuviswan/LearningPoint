using Mediator.Services;

namespace Mediator.Mediator;
public abstract class MediatorBase
{
    public abstract void SendMessage(string message, ServiceBase sender);
}
