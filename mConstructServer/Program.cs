using System;
using Topshelf;

namespace mConstructServer
{
    class Program
    {

        public static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<GrpcServer>(s =>
                {
                    s.ConstructUsing(server => new GrpcServer());
                    s.WhenStarted((server, host) =>
                    {
                        host.RequestAdditionalTime(TimeSpan.FromMinutes(2.0));
                        return server.start();
                    }
                    );
                    s.WhenStopped(server => server.stop());

                });

                x.RunAsLocalSystem();

                x.SetServiceName("MobileAppsGrpcServer");
                x.SetDisplayName("Mobile Apps Grpc Server");
                x.SetDescription("This service runs a grpc host server for mobile application requests.");

            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
