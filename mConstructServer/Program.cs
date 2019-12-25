using Grpc.Core;
using Grpc.services;
using mConstructServer.services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace mConstructServer
{
    class Program
    {
        const int Port = 50051;

        public static void Main(string[] args)
        {
            var cacert = File.ReadAllText(@"certificate\ca.cert");
            //var servercert = File.ReadAllText(@"certificate\server.pem");
            //var serverkey = File.ReadAllText(@"certificate\server.key");
            var keyCertificatePairs = new List<KeyCertificatePair>();
            //keyCertificatePairs.Add(new KeyCertificatePair(servercert, serverkey));

            var credentials = new SslServerCredentials(keyCertificatePairs, cacert, SslClientCertificateRequestType.DontRequest);
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
                Ports = { new ServerPort(GetAllLocalIPv4(NetworkInterfaceType.Wireless80211)[0], Port, credentials /*SslServerCredentials.Insecure*/) }
            };
            server.Start();

            Console.WriteLine("mConstruct server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }

        private static string[] GetAllLocalIPv4(NetworkInterfaceType _type)
        {
            List<string> ipAddrList = new List<string>();
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipAddrList.Add(ip.Address.ToString());
                        }
                    }
                }
            }
            return ipAddrList.ToArray();
        }
    }
}
