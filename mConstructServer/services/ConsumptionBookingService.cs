using Grpc.common;
using Grpc.Core;
using Grpc.services;
using System;
using System.Threading.Tasks;
using Status = Grpc.Core.Status;

namespace mConstructServer.services
{
    class ConsumptionBookingService : ConsumptionBooking.ConsumptionBookingBase
    {
        public override Task<BoQResponse> GetBoQ(BoQRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");

            return base.GetBoQ(request, context);
        }

        public override Task<Response> SaveBoQ(SaveBoQRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");
            if (request.BoqList == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("BoqList = {0}", request.BoqList)), "Boq list can not be null");

            return base.SaveBoQ(request, context);
        }


        public override Task<SoQResponse> GetSoQ(SoQRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");

            return base.GetSoQ(request, context);
        }

        public override Task<Response> SaveSoQ(SaveSoQRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");
            if (request.SoqList == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("SoqList = {0}", request.SoqList)), "Soq list can not be null");

            return base.SaveSoQ(request, context);
        }


        public override Task<BoQResponse> GetSummaryBoQForSplitterTask(SummaryBoQForSplitterTaskRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");
            if (request.SplitterPort == SplitterPort.NoPort)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("SplitterPort = {0}", request.SplitterPort)), "Invalid splitter port");

            return base.GetSummaryBoQForSplitterTask(request, context);
        }

        public override Task<Response> SaveSummaryBoQForSplitterTask(SaveSummaryBoQForSplitterTaskRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");
            if (request.BoqList == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("BoqList = {0}", request.BoqList)), "Boq list can not be null");
            if (request.SplitterPort == SplitterPort.NoPort)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("SplitterPort = {0}", request.SplitterPort)), "Invalid splitter port");


            return base.SaveSummaryBoQForSplitterTask(request, context);
        }


        public override Task<BoQResponse> GetSummaryBoQForFeederTask(SummaryBoQForFeederTaskRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");

            return base.GetSummaryBoQForFeederTask(request, context);
        }

        public override Task<Response> SaveSummaryBoQForFeederTask(SaveSummaryBoQForFeederTaskRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");
            if (request.BoqList == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("BoqList = {0}", request.BoqList)), "Boq list can not be null");

            return base.SaveSummaryBoQForFeederTask(request, context);
        }

        public override Task<SoQResponse> GetSummarySoQForSplitterTask(SummarySoQForSplitterTaskRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");
            if (request.SplitterPort == SplitterPort.NoPort)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("SplitterPort = {0}", request.SplitterPort)), "Invalid splitter port");


            return base.GetSummarySoQForSplitterTask(request, context);
        }

        public override Task<Response> SaveSummarySoQForSplitterTask(SaveSummarySoQForSplitterTaskRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");
            if (request.SoqList == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("SoqList = {0}", request.SoqList)), "Soq list can not be null");
            if (request.SplitterPort == SplitterPort.NoPort)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("SplitterPort = {0}", request.SplitterPort)), "Invalid splitter port");


            return base.SaveSummarySoQForSplitterTask(request, context);
        }

        public override Task<SoQResponse> GetSummarySoQForFeederTask(SummarySoQForFeederTaskRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");

            return base.GetSummarySoQForFeederTask(request, context);
        }

        public override Task<Response> SaveSummarySoQForFeederTask(SaveSummarySoQForFeederTaskRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");
            if (request.SoqList == null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("SoqList = {0}", request.SoqList)), "Soq list can not be null");

            return base.SaveSummarySoQForFeederTask(request, context);
        }

        public override Task<BoQResponse> GetSummaryBoQForOffer(SummaryBoQForOfferRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.OfferCode))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("OfferCode = {0}", request.OfferCode)), "Offer code can not be null or empty");
            if (request.OfferCategory == OfferCategory.NoCategory)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("OfferCategory = {0}", request.OfferCategory)), "Invalid offer category");
            if (string.IsNullOrEmpty(request.FsaID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("FsaID = {0}", request.FsaID)), "Fsa ID can not be null or empty");

            return base.GetSummaryBoQForOffer(request, context);
        }

        public override Task<SoQResponse> GetSummarySoQForOffer(SummarySoQForOfferRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.OfferCode))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("OfferCode = {0}", request.OfferCode)), "Offer code can not be null or empty");
            if (request.OfferCategory == OfferCategory.NoCategory)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("OfferCategory = {0}", request.OfferCategory)), "Invalid offer category");
            if (string.IsNullOrEmpty(request.FsaID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("FsaID = {0}", request.FsaID)), "Fsa ID can not be null or empty");

            return base.GetSummarySoQForOffer(request, context);
        }

        public override Task<BoQResponse> GetAdditionalBoQ(AdditionalBoQRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");

            return base.GetAdditionalBoQ(request, context);
        }

        public override Task<SoQResponse> GetAdditionalSoQ(AdditionalSoQRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");

            return base.GetAdditionalSoQ(request, context);
        }         
    }
}
