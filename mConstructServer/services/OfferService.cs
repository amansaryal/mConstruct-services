using Grpc.common;
using Grpc.Core;
using Grpc.services;
using System;
using System.Threading.Tasks;
using Status = Grpc.Core.Status;

namespace mConstructServer.services
{
    class OfferService : Offer.OfferBase
    {

        public override Task<PossibleOffersResponse> GetPossibleSplitterOffers(OffersRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.FsaID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("FsaID = {0}", request.FsaID)), "Fsa ID can not be null or empty");

            return base.GetPossibleSplitterOffers(request, context);
        }

        public override Task<PossibleOffersResponse> GetPossibleFeederOffers(OffersRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.FsaID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("FsaID = {0}", request.FsaID)), "Fsa ID can not be null or empty");

            return base.GetPossibleFeederOffers(request, context);
        }

        public override Task<OfferSummary> GetSplitterPossibleOfferSummary(SplitterPossibleOfferSummaryRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");
            if (request.SplitterPort == SplitterPort.NoPort)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("SplitterPort = {0}", request.SplitterPort)), "Invalid splitter port");

            return base.GetSplitterPossibleOfferSummary(request, context);
        }

        public override Task<OfferSummary> GetFeederPossibleOfferSummary(FeederPossibleOfferSummaryRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");

            return base.GetFeederPossibleOfferSummary(request, context);
        }

        public override Task<OfferDetails> CreateSplitterOffer(CreateSplitterOfferRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");
            if (string.IsNullOrEmpty(request.FsaID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("FsaID = {0}", request.FsaID)), "Fsa ID can not be null or empty");
            if (request.SplitterPort == SplitterPort.NoPort)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("SplitterPort = {0}", request.SplitterPort)), "Invalid splitter port");

            return base.CreateSplitterOffer(request, context);
        }

        public override Task<OfferDetails> CreateFeederOffer(CreateFeederOfferRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.TaskID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("TaskID = {0}", request.TaskID)), "Task ID can not be null or empty");
            if (string.IsNullOrEmpty(request.FsaID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("FsaID = {0}", request.FsaID)), "Fsa ID can not be null or empty");

            return base.CreateFeederOffer(request, context);
        }

        public override Task<OffersResponse> GetSplitterOffers(OffersRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.FsaID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("FsaID = {0}", request.FsaID)), "Fsa ID can not be null or empty");

            return base.GetSplitterOffers(request, context);
        }

        public override Task<OffersResponse> GetFeederOffers(OffersRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.FsaID))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("FsaID = {0}", request.FsaID)), "Fsa ID can not be null or empty");

            return base.GetFeederOffers(request, context);
        }

        public override Task<OfferSummary> GetOfferSummary(OfferSummaryRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.OfferCode))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("OfferCode = {0}", request.OfferCode)), "Offer code can not be null or empty");

            return base.GetOfferSummary(request, context);
        }

        public override Task<GeoDataResponse> GetGeoDataForOfferSubTasks(GeoDataRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (request.LayerWiseTaskList == null)
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("LayerWiseTaskList = {0}", request.LayerWiseTaskList)), "Task list can not be null");

            return base.GetGeoDataForOfferSubTasks(request, context);
        }

        public override Task<Response> AcceptOffer(AcceptOfferRequest request, ServerCallContext context)
        {
            SessionUtil.CheckSession(request.Username, MetadataUtil.GetToken(context));

            if (string.IsNullOrEmpty(request.OfferCode))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("OfferCode = {0}", request.OfferCode)), "Offer code can not be null or empty");


            return base.AcceptOffer(request, context);
        }
    }
}
