﻿using ShoppingCenterWCFServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCenterWCFServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //ServiceHost selfHost = new ServiceHost(typeof(CategoryService));

            //try
            //{
            //    selfHost.Open();
            //    Console.WriteLine("The service is ready.");
            //    Console.WriteLine("Press <ENTER> to terminate service.");
            //    Console.ReadLine();
            //    selfHost.Close();
            //}
            //catch (CommunicationException ce)
            //{
            //    Console.WriteLine("An exception occurred: {0}", ce.Message);
            //    selfHost.Abort();
            //}

            // Step 1 Create a URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:8000/GettingStarted/");

            // Step 2 Create a ServiceHost instance
            ServiceHost selfHost = new ServiceHost(typeof(ServiceCategory), baseAddress);

            try
            {
                // Step 3 Add a service endpoint.
                selfHost.AddServiceEndpoint(typeof(IServiceCategory), new WSHttpBinding(), "ServiceCategory");

                // Step 4 Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Step 5 Start the service.
                selfHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();

                // Close the ServiceHostBase to shutdown the service.
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }

            Console.ReadLine();
        }
    }
}
