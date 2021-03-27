using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace Travely.PropertyManager.API.Interceptors
{
    public class ErrorHandlingInterceptor : Interceptor
    {
        public Action<Exception> ExceptionLogger { get; set; }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            TResponse response;

            try
            {
                response = await continuation(request, context);
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }

            return response;
        }
    }
}
