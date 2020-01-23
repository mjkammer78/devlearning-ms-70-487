using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace HelloWorldService
{
    [ServiceContract]
    public interface IHelloWorldService
    {
        [OperationContract]
        string GetStandardGreeting();

        [OperationContract]
        [FaultContract(typeof(ArgumentNullException))]
        Greeting ReturnCustomGreeting(string yourName);
    }

    [DataContract]
    public class Greeting
    {
        string yourName = "Joe";
        string stringValue = "Hello ";

        [DataMember]
        public string YourName
        {
            get { return yourName; }
            set { yourName = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
