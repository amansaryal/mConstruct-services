using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mConstructServer
{
    class MetadataUtil
    {
        public static string GetToken(ServerCallContext context)
        {
            Metadata.Entry metadataEntry = context.RequestHeaders.FirstOrDefault(m =>
            String.Equals(m.Key, "session-token", StringComparison.Ordinal));

            if (metadataEntry.Equals(default(Metadata.Entry)) || metadataEntry.Value == null)
            {
                return null;
            }

            return metadataEntry.Value.ToString();
        }
    }
}
