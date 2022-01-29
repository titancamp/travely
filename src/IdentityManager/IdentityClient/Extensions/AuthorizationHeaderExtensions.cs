using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Grpc.Core
{
    public static class TravelyAuthorizationHeaderExtensions
    {
        //TODO: do changes so grpc will automatically add header
        public static ServerCallContext DelegateTravelAuthorization(this ServerCallContext serverCallContext, HttpContext httpContext)
        {
            StringValues token = new StringValues();
            httpContext.Request.Headers.TryGetValue("access_token", out token);
            serverCallContext.RequestHeaders.Add("Authorization", $"Bearer {token}");

            return serverCallContext;
        }
    }
}
