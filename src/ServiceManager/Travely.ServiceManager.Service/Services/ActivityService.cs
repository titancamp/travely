using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travely.ServiceManager.Service
{
    public class ActivityService : ActivityProto.ActivityProtoBase
    {
        public override Task<ActivityReponce> CreateActivity(Activity activity, ServerCallContext context)
        {
            return Task.FromResult(new ActivityReponce
            {
                Message = "Successfully cerated new activity",
                Status = ResponseStatus.ActivityResponseSuccess
            });
        }
    }
}
