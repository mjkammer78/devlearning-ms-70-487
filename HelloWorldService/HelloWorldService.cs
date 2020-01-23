using System;
using System.ServiceModel;

namespace HelloWorldService
{
    public class HelloWorldService : IHelloWorldService
    {
        public string GetStandardGreeting()
        {
            return $"Hello someone!";
        }

        public Greeting ReturnCustomGreeting(string yourName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(yourName))
                {
                    throw new ArgumentNullException(nameof(yourName));
                }

                return new Greeting
                {
                    YourName = yourName
                };
            }
            catch(ArgumentNullException ex)
            {
                throw new FaultException<ArgumentNullException>(ex, 
                    new FaultReason("Operation was called with incomplete input parameters"));
            }
        }
    }
}
