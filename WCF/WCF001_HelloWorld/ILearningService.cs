using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF001_HelloWorld
{
    [ServiceContract]
    public interface ILearningService
    {
        [OperationContract]
        string GetUserName();

        [OperationContract]
        Parent GetParents();
        
    }

    [DataContract]
    public class Person
    {
        [DataMember]
        public string Father { get; set; }
        [DataMember]
        public string Mother { get; set; }
    }
}
