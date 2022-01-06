using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Travely.Shared.IdentityClient.Authorization.Extensions
{
    public static class TravelyAuthorizationHeaderExtensions
    {
        //TODO: do changes so grpc will automatically add header
        public static ServerCallContext DelegateTravelAuthorization(this ServerCallContext serverCallContext, HttpContext httpContext)
        {
            var token = new StringValues();
            httpContext.Request.Headers.TryGetValue("access_token", out token);
            serverCallContext.RequestHeaders.Add("Authorization", $"Bearer {token}");

            return serverCallContext;
        }
    }
}
