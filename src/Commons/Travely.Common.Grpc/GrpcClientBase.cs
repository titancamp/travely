using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Travely.Common.CustomExceptions;
using Travely.Common.Grpc.Abstraction;

namespace Travely.Common.Grpc
{
    public abstract class GrpcClientBase<T> where T : ClientBase<T>
    {
        public GrpcClientBase(IServiceSettingsProvider<T> serviceSettingsProvider)
        {
            ServiceSettingsProvider = serviceSettingsProvider;
        }

        protected IServiceSettingsProvider<T> ServiceSettingsProvider { get; }

        protected virtual T CreateGrpcClient(GrpcChannel channel)
        {
            return (T) Activator.CreateInstance(typeof(T), new object[] { channel });
        }

        protected GrpcChannel GetClientGrpcChannel()
        {
            string clientBaseAddress = ServiceSettingsProvider.Settings.Url;
            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (_, _, _, _) => true,
            };

            var channel = GrpcChannel.ForAddress(
                clientBaseAddress,
                new GrpcChannelOptions
                {
                    HttpHandler = httpHandler
                });

            return channel;
        }

        protected async Task<TResponse> HandleAsync<TResponse>(Func<T, Task<TResponse>> continuation)
        {
            try
            {
                var channel = GetClientGrpcChannel();
                var client = CreateGrpcClient(channel);

                return await continuation(client);
            }
            catch (RpcException ex)
            {
                throw new BadRequestException(ex.Status.Detail);
            }
            catch
            {
                throw;
            }
        }

        protected async Task HandleAsync(Func<T, Task> continuation)
        {
            try
            {
                var channel = GetClientGrpcChannel();
                var client = CreateGrpcClient(channel);

                await continuation(client);
            }
            catch (RpcException ex)
            {
                throw new BadRequestException(ex.Status.Detail);
            }
            catch
            {
                throw;
            }
        }
    }
}
