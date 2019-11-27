using Grpc.common;
using Grpc.Core;
using Grpc.services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Status = Grpc.Core.Status;

namespace mConstructServer.services
{
    class TaskService : Grpc.services.Task.TaskBase
    {
        public override Task<AssignedFsaResponse> GetAssignedFsas(AssignedFsaRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));
            
            if (string.IsNullOrEmpty(request.JpID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("JpID = {0}", request.JpID)), "JioPoint ID can not be null or empty");
            if (request.Activity == Activity.DefaultActivity)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("Activity = {0}", request.Activity)), "Invalid activity");


            return base.GetAssignedFsas(request, context);
        }

        public override Task<AssignedDsaResponse> GetAssignedDsas(AssignedDsaRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.FsaID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("FsaID = {0}", request.FsaID)), "FSA ID can not be null or empty");
            if (request.Activity == Activity.DefaultActivity)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("Activity = {0}", request.Activity)), "Invalid activity");

            return base.GetAssignedDsas(request, context);
        }

        public override Task<AssignedTaskResponse> GetAssignedTasks(AssignedTaskRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.DsaID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("DsaID = {0}", request.DsaID)), "DSA ID can not be null or empty");
            if (request.Activity == Activity.DefaultActivity)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("Activity = {0}", request.Activity)), "Invalid activity");


            return base.GetAssignedTasks(request, context);
        }

        public override Task<TaskData> GetTaskData(TaskDataRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));
            
            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");
            if (request.Layer == Grpc.common.Layer.None)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("Layer = {0}", request.Layer)), "Invalid layer");


            return base.GetTaskData(request, context);
        }

        public override Task<Response> SaveTaskData(SaveTaskDataRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));
            
            if (request.TaskData == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("TaskData = {0}", request.TaskData)), "Task Data can not be null");
          

            return base.SaveTaskData(request, context);
        }

        public override Task<OTDRData> GetOTDRData(OTDRDataRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");

            return base.GetOTDRData(request, context);
        }

        public override Task<Response> SaveOTDRData(SaveOTDRDataRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (request.OtdrData == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("OtdrData = {0}", request.OtdrData)), "Otdr Data can not be null");

            return base.SaveOTDRData(request, context);
        }

        public override Task<PMTestData> GetPMTestData(PMTestDataRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");

            return base.GetPMTestData(request, context);
        }

        public override Task<Response> SavePMTestData(SavePMTestDataRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (request.PmTestData == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("PmTestData = {0}", request.PmTestData)), "PM Test Data can not be null");

            return base.SavePMTestData(request, context);
        }

        public override Task<Response> DeclareRFS(RFSRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");
            if (string.IsNullOrEmpty(request.FsaID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("FsaID = {0}", request.FsaID)), "FSA ID can not be null or empty");
            if (request.RfsStatus == RFSRequest.Types.RFSStatus.None)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("RfsStatus = {0}", request.RfsStatus)), "Invalid RFS Status");

            return base.DeclareRFS(request, context);
        }

        public override Task<TaskHistory> GetTaskHistory(TaskHistoryRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");

            return base.GetTaskHistory(request, context);
        }

        public override Task<ConstructionNotes> GetConstructionNotes(ConstructionNotesRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");

            return base.GetConstructionNotes(request, context);
        }

        public override Task<Response> SaveConstructionNotes(SaveConstructionNotesRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");


            return base.SaveConstructionNotes(request, context);
        }

        public override Task<Response> UploadPhotoEvidence(UploadPhotoEvidenceRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");

            return base.UploadPhotoEvidence(request, context);
        }

        public override Task<PhotoEvidenceResponse> GetPhotoEvidence(PhotoEvidenceRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");

            return base.GetPhotoEvidence(request, context);
        }
    }
}
