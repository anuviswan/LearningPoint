using Mediator.Services;

namespace Mediator.Mediator;
public class ConcreteMediator : MediatorBase
{
    private ServiceA _serviceA;
    private ServiceB _serviceB;

    public ConcreteMediator(ServiceA serviceA,ServiceB serviceB)
    {
        (_serviceA,_serviceB) = (serviceA,serviceB);
    }
    public override void SendMessage(string message, ServiceBase sender)
    {
        switch (sender)
        {
            case ServiceA _ :

                if(string.Equals("one", message, StringComparison.InvariantCultureIgnoreCase))
                {
                    _serviceB.DoOperationOne();
                    break;
                }
                else if (string.Equals("two", message, StringComparison.InvariantCultureIgnoreCase))
                {
                    _serviceB.DoOperationTwo();
                    break;
                }
                _serviceB.DoOperationOne();
                _serviceB.DoOperationTwo();
                break;

            case ServiceB _:

                _serviceA.DoOperationFour();
                break;
        }

    }
}
