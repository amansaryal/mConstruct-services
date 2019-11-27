using System;
using System.Threading.Tasks;
using Grpc.common;
using Grpc.Core;
using Grpc.services;
using Status = Grpc.Core.Status;

namespace mConstructServer.services
{
    public class SessionService : Session.SessionBase
    {
        private string MCONSTRUCT_VERSION = "2.3";

        public override Task<UserSession> Login(LoginRequest request, ServerCallContext context)
        {

            if (request.AppName == Appname.Noname)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("AppName = {0}", request.AppName)), "Invalid app name");
            if (string.IsNullOrEmpty(request.Username))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("Username = {0}", request.Username)), "Username can not be null or empty");
            if (string.IsNullOrEmpty(request.Password))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("Password = {0}", request.Password)), "Password can not be null or empty");
            if (string.IsNullOrEmpty(request.Imei))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("Imei = {0}", request.Imei)), "Imei can not be null or empty");
            if (string.IsNullOrEmpty(request.IpAddress))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("IpAddress = {0}", request.IpAddress)), "IpAddress can not be null or empty");



            UserSession userSession = new UserSession();
            userSession.Token = "abcd1234";
            userSession.Roles.Add(Role.FieldEngineer);
            userSession.Roles.Add(Role.QualityEngineer);
            userSession.AppVersion = MCONSTRUCT_VERSION;
            return System.Threading.Tasks.Task.FromResult(userSession);
        }

        public override Task<Response> Logout(LogoutRequest request, ServerCallContext context)
        {
            if (string.IsNullOrEmpty(request.Username))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("Username = {0}", request.Username)), "Username can not be null or empty");
            if (request.AppName == Appname.Noname)
                throw new RpcException(new Status(StatusCode.InvalidArgument, String.Format("AppName = {0}", request.AppName)), "Invalid app name");

            return System.Threading.Tasks.Task.FromResult(new Response
            {
                Message = "Logged out"
            });
        }

    }
}