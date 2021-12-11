using Mediator.Mediator;
using Mediator.Services;

Console.WriteLine("Demo for Mediator Pattern");



var serviceA = new ServiceA();
var serviceB = new ServiceB();

var mediator = new ConcreteMediator(serviceA,serviceB);

serviceA.SetMediator(mediator);
serviceB.SetMediator(mediator);

Console.WriteLine($"{nameof(ServiceA)}.One");
serviceA.RaiseNotification("One");

Console.WriteLine($"{nameof(ServiceA)}.Two");
serviceA.RaiseNotification("Two");

Console.WriteLine($"{nameof(ServiceA)}.Empty");
serviceA.RaiseNotification(String.Empty);

Console.WriteLine($"{nameof(ServiceB)}.Three");
serviceB.SendMessage("Three");

Console.WriteLine($"{nameof(ServiceB)}.Four");
serviceB.SendMessage("Four");

Console.WriteLine($"{nameof(ServiceB)}.Empty");
serviceB.SendMessage(String.Empty);