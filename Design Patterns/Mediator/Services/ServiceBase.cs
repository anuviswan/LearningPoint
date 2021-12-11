using Mediator.Mediator;

namespace Mediator.Services;
public class ServiceBase
{
    protected MediatorBase _mediator;

    public void SetMediator(MediatorBase mediator)
    {
        _mediator = mediator;
    }
}
