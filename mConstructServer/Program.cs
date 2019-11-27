using Grpc.Core;
using Grpc.services;
using mConstructServer.services;
using System;
using System.Collections.Generic;
using System.IO;

namespace mConstructServer
{
    class Program
    {
        const int Port = 50051;

        public static void Main(string[] args)
        {
            var cacert = File.ReadAllText(@"certificate\ca.cert");
            var servercert = File.ReadAllText(@"certificate\server.pem");
            var serverkey = File.ReadAllText(@"certificate\server.key");
            var keyCertificatePairs = new List<KeyCertificatePair>();
            keyCertificatePairs.Add(new KeyCertificatePair(servercert, serverkey));

            var credentials = new SslServerCredentials(keyCertificatePairs, cacert, SslClientCertificateRequestType.RequestAndRequireAndVerify);
            Server server = new Server
            {
                Services = { 
                    Session.BindService(new SessionService()),
                    K2.BindService(new K2Service()),
                    Dashboard.BindService(new DashboardService()),
                    Task.BindService(new TaskService()),
                    ConsumptionBooking.BindService(new ConsumptionBookingService()),
                    Offer.BindService(new OfferService()),
                    QC.BindService(new QCService())
                },
                Ports = { new ServerPort("192.168.29.91", Port, credentials /*SslServerCredentials.Insecure*/) }
            };
            server.Start();

            Console.WriteLine("mConstruct server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
