using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataService;

namespace WCF001_HelloWorld
{
    public class HelloWorldService : ILearningService
    {
        private IDataService _data;
        public HelloWorldService() => _data = new MockDataService();
        
        public Parent GetParents() => _data.GetParents();
        

        public string GetUserName() => _data.GetName();
    }
}
