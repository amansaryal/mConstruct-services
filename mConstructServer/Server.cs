using Grpc.Core;
using Grpc.services;
using mConstructServer.services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace mConstructServer
{
    class GrpcServer
    {
        const int Port = 50051;
        private Server server;

        public GrpcServer()
        {
            var cacert = File.ReadAllText(@"certificate\ca.cert");
            var servercert = File.ReadAllText(@"certificate\service.pem");
            var serverkey = File.ReadAllText(@"certificate\service.key");
            var keyCertificatePairs = new List<KeyCertificatePair>();
            keyCertificatePairs.Add(new KeyCertificatePair(servercert, serverkey));

            var credentials = new SslServerCredentials(keyCertificatePairs, cacert, SslClientCertificateRequestType.DontRequest);

            server = new Server
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
        }

        public bool start()
        {
            server.Start();
            return true;
        }

        public bool stop()
        {
            server.ShutdownAsync().Wait();
            return false;
        }

    }
}
