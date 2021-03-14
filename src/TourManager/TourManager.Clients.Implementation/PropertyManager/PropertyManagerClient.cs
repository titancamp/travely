using Grpc.Core;
using Grpc.Net.Client;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TourManager.Clients.Abstraction.PropertyManager;
using TourManager.Clients.Abstraction.Settings;
using TourManager.Clients.Implementation.Mappers;
using TourManager.Common.Clients.PropertyManager;
using Travely.PropertyManager.API;
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

        public async Task<int> AddPropertyAsync(AddPropertyRequest model)
        {
            var client = GetPropertyClient();

            var request = Mapping.Mapper.Map<AddPropertyRequestDto>(model);

            var response = await client.AddPropertyAsync(request);

            return response.Id;
        }

        public async Task<IEnumerable<PropertyResponse>> GetPropertiesAsync()
        {
            var client = GetPropertyClient();
            var properties = new List<PropertyResponse>();

            await foreach (var response in client.GetProperties(new GetPropertiesRequest()).ResponseStream.ReadAllAsync())
            {
                properties.Add(Mapping.Mapper.Map<PropertyResponse>(response));
            }

            return properties;
        }

        private Property.PropertyClient GetPropertyClient()
        {
            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            var channel = GrpcChannel.ForAddress(
                _serviceSettingsProvider.ComposePropertyServiceUrl(),
                new GrpcChannelOptions
                {
                    HttpHandler = httpHandler
                });

            return new Property.PropertyClient(channel);
        }
    }
}
