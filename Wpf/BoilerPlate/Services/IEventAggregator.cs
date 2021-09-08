using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerPlate.Services
{
    public interface IEventAggregator
    {
        void Subscribe(object subscriber);
        void Unsubscribe(object subscriber);
        void PublishMessage(object message);
    }
}
