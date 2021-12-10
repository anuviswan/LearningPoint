using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsAndMediatR.Domain.Entities
{
    public class Address
    {
        public string HouseName { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string Country { get; set; }
    }
}
