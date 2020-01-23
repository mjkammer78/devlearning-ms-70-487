using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace SelfHostHelloWorldService
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = new Uri("http://localhost:8080/hello");

            // Create the ServiceHost.
            using (var host = new ServiceHost(typeof(HelloWorldService.HelloWorldService), baseAddress))
            {
                // Enable metadata publishing.
                var smb = new ServiceMetadataBehavior
                {
                    HttpGetEnabled = true
                };
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);

                //explicitly add an endpoint for MetaDataExchange
                host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
                    MetadataExchangeBindings.CreateMexHttpBinding(), "mexBindingHttp");

                //explicitly add some endpoints
                host.AddDefaultEndpoints();

                // Open the ServiceHost to start listening for messages. If
                // no endpoints are explicitly configured, the runtime will create
                // one endpoint per base address for each service contract implemented
                // by the service.
                host.Open();

                Console.WriteLine("The service is ready at {0}", baseAddress);

                //directly access an endpoint for interaction:
                var uri = host.BaseAddresses[0];

                var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
                var endpoint = new EndpointAddress(uri);
                var factory = new ChannelFactory<HelloWorldService.IHelloWorldService>(binding, endpoint);

                var channel = factory.CreateChannel();
                var response = channel.GetStandardGreeting();


                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }

            //test using wcftestclient.exe (developer command prompt)
        }
    }
}
