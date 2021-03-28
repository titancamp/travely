using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using TourManager.Clients.Abstraction.PropertyManager;
using TourManager.Clients.Abstraction.Settings;
using TourManager.Clients.Implementation.Mappers;
using TourManager.Common.Clients.PropertyManager;
using Travely.PropertyManager.API;
using Travely.Services.Common.CustomExceptions;
using AddPropertyRequest = TourManager.Common.Clients.PropertyManager.AddPropertyRequest;
using AddPropertyRequestDto = Travely.PropertyManager.API.AddPropertyRequest;

namespace TourManager.Clients.Implementation.PropertyManager
{
    public class PropertyManagerClient : IPropertyManagerClient
    {
        private readonly IServiceSettingsProvider _serviceSettingsProvider;

        public PropertyManagerClient(IServiceSettingsProvider serviceSettingsProvider)
        {
            _serviceSettingsProvider = serviceSettingsProvider;
        }

        public Task<int> AddPropertyAsync(int agencyId, AddPropertyRequest model)
        {
            return HandleAsync(async () =>
            {
                var client = GetPropertyClient();

                var request = Mapping.Mapper.Map<AddPropertyRequestDto>(model, opt =>
                    opt.AfterMap((src, dest) => dest.AgencyId = agencyId));

                var response = await client.AddPropertyAsync(request);

                return response.Id;
            });
        }

        public Task DeletePropertyAsync(int agencyId, int id)
        {
            return HandleAsync(async () =>
            {
                var client = GetPropertyClient();

                await client.DeletePropertyAsync(new DeletePropertyRequest { Id = id, AgencyId = agencyId });
            });
        }

        public Task<PropertyResponse> GetByIdAsync(int agencyId, int id)
        {
            return HandleAsync(async () =>
            {
                var client = GetPropertyClient();

                var property = await client.GetPropertyByIdAsync(new GetPropertyByIdRequest { Id = id, AgencyId = agencyId });

                return Mapping.Mapper.Map<PropertyResponse>(property);
            });
        }

        public Task<IEnumerable<PropertyResponse>> GetPropertiesAsync(int agencyId)
        {
            return HandleAsync<IEnumerable<PropertyResponse>>(async () =>
            {
                var client = GetPropertyClient();
                var properties = new List<PropertyResponse>();
                var request = new GetPropertiesRequest { AgencyId = agencyId };

                await foreach (var response in client.GetProperties(request).ResponseStream.ReadAllAsync())
                {
                    properties.Add(Mapping.Mapper.Map<PropertyResponse>(response));
                }

                return properties;
            });
        }

        private Property.PropertyClient GetPropertyClient()
        {
            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
            };

            var channel = GrpcChannel.ForAddress(
                _serviceSettingsProvider.ComposePropertyServiceUrl(),
                new GrpcChannelOptions
                {
                    HttpHandler = httpHandler
                });

            return new Property.PropertyClient(channel);
        }

        private static async Task<TResponse> HandleAsync<TResponse>(Func<Task<TResponse>> continuation)
        {
            try
            {
                return await continuation();
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

        private static async Task HandleAsync(Func<Task> continuation)
        {
            try
            {
                await continuation();
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
