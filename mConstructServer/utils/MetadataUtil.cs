using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace mConstructServer
{
    class MetadataUtil
    {
        public static string GetToken(ServerCallContext context)
        {
            Metadata.Entry entry = new Metadata.Entry("sessionToken", "");
            int index = context.RequestHeaders.IndexOf(entry);

            return index >= 0 ? context.RequestHeaders[index].Value : entry.Value;
        }
    }
}
