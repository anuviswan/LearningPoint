using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator.Simple.Messages
{
    public class MessageBase
    {
        public object Sender { get; set; }
    }
}
