using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.services;
using Status = Grpc.Core.Status;

namespace mConstructServer.services
{
    public class DashboardService : Dashboard.DashboardBase
    {
        public override Task<DashboardData> GetDashboardData(DashboardDataRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));
            
            if (string.IsNullOrEmpty(request.JpID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("JpID = {0}", request.JpID)), "Jiopoint ID can not be null or empty");
            if (request.Role == Role.NoRole)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("Role = {0}", request.Role.ToString())), "Invalid user role");


            return base.GetDashboardData(request, context);
        }
    }
}