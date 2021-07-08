using EventAggregator.Simple.Messages;
using EventAggregator.Simple.Subscribers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Assert.AreEqual(2, eventAggregator.SubscriptionCount<UserLoggedInMessage>());
            var message = new UserLoggedInMessage("Tom", this);
            eventAggregator.Publish(message);

            mockSubscriberAlpha.Verify(x => x.Invoke(message), Times.Once);
            mockSubscriberBeta.Verify(x => x.InvokeBetaHandler(message), Times.Once);


        }
    }
}
