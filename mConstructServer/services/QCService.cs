using Grpc.common;
using Grpc.Core;
using Grpc.services;
using System;
using System.Threading.Tasks;
using Status = Grpc.Core.Status;

namespace mConstructServer.services
{
    public class QCService : QC.QCBase
    {
        public override Task<QCResponse> GetQualityCheckpoints(QCRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");
            if (request.Layer == Layer.None)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("Layer = {0}", request.Layer)), "Invalid layer");

            return base.GetQualityCheckpoints(request, context);
        }

        public override Task<Response> SaveQualityCheckpoints(SaveQCRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");
            if (request.Layer == Layer.None)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("Layer = {0}", request.Layer)), "Invalid layer");
            if (request.QualityCheckpoint == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("QualityCheckpoints = {0}", request.QualityCheckpoint)), "Quality checkpoints list can not be null");

            if (request.IsApprovedCase == SaveQCRequest.IsApprovedOneofCase.None)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("IsApprovedCase = {0}", request.IsApprovedCase)), "Quality check approval must be given");

            return base.SaveQualityCheckpoints(request, context);
        }

        public override Task<TaskHistory> GetQCHistory(QCHistoryRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");
            if (string.IsNullOrEmpty(request.QuestionID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("QuestionID = {0}", request.QuestionID)), "Question ID can not be null or empty");

            return base.GetQCHistory(request, context);
        }
    }
}