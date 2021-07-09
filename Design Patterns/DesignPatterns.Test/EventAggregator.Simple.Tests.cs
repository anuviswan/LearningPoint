using EventAggregator.Simple.Messages;
using EventAggregator.Simple.Subscribers;
using Moq;
using NUnit.Framework;

namespace DesignPatterns.Test
{
    public class EventAggregatorSimpleTests
    {
        [Test]
        public void EventAggregatorSimpleTest()
        {
            var eventAggregator = new EventAggregator.Simple.EventAggregator();
            var mockSubscriberAlpha = new Moq.Mock<ISubscriberAlpha>();
            var mockSubscriberBeta = new Moq.Mock<ISubscriberBeta>();
            var subscriberAlpha = mockSubscriberAlpha.Object;
            var subscriberBeta = mockSubscriberBeta.Object;

            eventAggregator.Subscribe<UserLoggedInMessage>(subscriberAlpha,subscriberAlpha.Invoke);
            eventAggregator.Subscribe<UserLoggedInMessage>(subscriberBeta,subscriberBeta.InvokeBetaHandler);
            eventAggregator.Subscribe<UserLoggedOutMessage>(subscriberAlpha, subscriberAlpha.Invoke);
            eventAggregator.Subscribe<UserLoggedOutMessage>(subscriberBeta, subscriberBeta.InvokeBetaHandler);

            Assert.AreEqual(2, eventAggregator.SubscriptionCount<UserLoggedInMessage>());
            Assert.AreEqual(2, eventAggregator.SubscriptionCount<UserLoggedOutMessage>());

            var loggedInMessage = new UserLoggedInMessage("Tom", this);
            eventAggregator.Publish(loggedInMessage);


            mockSubscriberAlpha.Verify(x => x.Invoke(loggedInMessage), Times.Once);
            mockSubscriberBeta.Verify(x => x.InvokeBetaHandler(loggedInMessage), Times.Once);

            mockSubscriberAlpha.Invocations.Clear();
            mockSubscriberBeta.Invocations.Clear();

            eventAggregator.Unsubscribe<UserLoggedInMessage>(subscriberAlpha);
            Assert.AreEqual(1, eventAggregator.SubscriptionCount<UserLoggedInMessage>());
            Assert.AreEqual(2, eventAggregator.SubscriptionCount<UserLoggedOutMessage>());
            eventAggregator.Publish(loggedInMessage);
            
            mockSubscriberAlpha.Verify(x => x.Invoke(loggedInMessage), Times.Never);
            mockSubscriberBeta.Verify(x => x.InvokeBetaHandler(loggedInMessage), Times.Once);

            eventAggregator.Unsubscribe(subscriberAlpha);
            eventAggregator.Unsubscribe(subscriberBeta);
            
            Assert.AreEqual(0, eventAggregator.SubscriptionCount<UserLoggedInMessage>());
            Assert.AreEqual(0, eventAggregator.SubscriptionCount<UserLoggedOutMessage>());
        }
    }
}
