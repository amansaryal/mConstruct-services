using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace mConstructServer
{
    class SessionUtil
    {
        public static void CheckSession(string username, string token)
        {
            if (string.IsNullOrEmpty(username))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("Username can not be null or empty")));
            if (string.IsNullOrEmpty(token))
                throw new RpcException(new Status(StatusCode.FailedPrecondition, String.Format("Token can not be null or empty")));

        }
    }
}
