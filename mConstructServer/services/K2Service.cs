using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.services;

namespace mConstructServer.services
{
    public class K2Service : K2.K2Base
    {
        public override Task<AssignedJioPointsResponse> GetAssignedJioPoints(AssignedJioPointsRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            AssignedJioPointsResponse assignedJioPointsResponse = new AssignedJioPointsResponse();
            return System.Threading.Tasks.Task.FromResult(assignedJioPointsResponse);
        }
    }
}