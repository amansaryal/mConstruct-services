using Grpc.Core;
using Grpc.services;
using System;
using System.IO;

namespace mConstructClient
{
    class Program
    {

        static Metadata headers = new Metadata();
        private static string token = "";

        //TODO


        static void Main(string[] args) //blocking call
        {
            var cacert = File.ReadAllText(@"certificate\ca.cert");
            var clientcert = File.ReadAllText(@"certificate\client.pem");
            var clientkey = File.ReadAllText(@"certificate\client.key");
            var keyCertificatePair = new KeyCertificatePair(clientcert, clientkey);

            var credentials = new SslCredentials(cacert, keyCertificatePair);
            Channel channel = new Channel("192.168.29.91",50051, credentials/*SslCredentials.Insecure*/);

            headers.Add(new Metadata.Entry("SessionToken", token));

            SessionService(channel);
            K2Service(channel);
            DashboardService(channel);
            TaskService(channel);
            ConsumptionBookingService(channel);
            OfferService(channel);
            QCService(channel);
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void SessionService(Channel channel)
        {
            Session.SessionClient client = new Session.SessionClient(channel);

            try
            {
                client.Login(new LoginRequest
                {
                }, new CallOptions(headers));
            }
            catch (RpcException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StatusCode);
                Console.WriteLine(e.Status.Detail);
            }
        }

        static void K2Service(Channel channel)
        {
            K2.K2Client client = new K2.K2Client(channel);

            try
            {
            }
            catch (RpcException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StatusCode);
                Console.WriteLine(e.Status.Detail);
            }
        }

        static void DashboardService(Channel channel)
        {
            Dashboard.DashboardClient client = new Dashboard.DashboardClient(channel);

            try
            {
            }
            catch (RpcException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StatusCode);
                Console.WriteLine(e.Status.Detail);
            }
        }

        static void TaskService(Channel channel)
        {
            Task.TaskClient client = new Task.TaskClient(channel);

            try
            {
            }
            catch (RpcException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StatusCode);
                Console.WriteLine(e.Status.Detail);
            }
        }

        static void ConsumptionBookingService(Channel channel)
        {
            ConsumptionBooking.ConsumptionBookingClient client = new ConsumptionBooking.ConsumptionBookingClient(channel);

            try
            {
            }
            catch (RpcException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StatusCode);
                Console.WriteLine(e.Status.Detail);
            }
        }

        static void OfferService(Channel channel)
        {
            Offer.OfferClient client = new Offer.OfferClient(channel);

            try
            {
            }
            catch (RpcException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StatusCode);
                Console.WriteLine(e.Status.Detail);
            }
        }

        static void QCService(Channel channel)
        {
            QC.QCClient client = new QC.QCClient(channel);

            try
            {
            }
            catch (RpcException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StatusCode);
                Console.WriteLine(e.Status.Detail);
            }
        }
    }

}
