using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using TourManager.Clients.Abstraction.Settings;
using Travely.Services.Common.CustomExceptions;

namespace TourManager.Clients.Implementation
{
    public abstract class GrpcClientBase<T> where T: ClientBase
    {
        public GrpcClientBase(IServiceSettingsProvider serviceSettingsProvider)
        {
            ServiceSettingsProvider = serviceSettingsProvider;
        }

        protected IServiceSettingsProvider ServiceSettingsProvider { get; }

        protected abstract T CreateGrpcClient();

        protected GrpcChannel GetClientGrpcChannel(string clientBaseAddress)
        {
            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (_,_,_,_) => true,
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
                var client = CreateGrpcClient();

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
                var client = CreateGrpcClient();

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
