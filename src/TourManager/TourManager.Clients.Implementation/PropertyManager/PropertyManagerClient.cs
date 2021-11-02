using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using TourManager.Clients.Abstraction.PropertyManager;
using TourManager.Clients.Abstraction.Settings;
using TourManager.Clients.Implementation.Mappers;
using TourManager.Service.Model.PropertyManager;
using Travely.PropertyManager.API;

namespace TourManager.Clients.Implementation.PropertyManager
{
    public class PropertyManagerClient : GrpcClientBase<Property.PropertyClient>, IPropertyManagerClient
    {
        public PropertyManagerClient(IServiceSettingsProvider serviceSettingsProvider)
            : base(serviceSettingsProvider)
        {
        }

        public Task<int> AddPropertyAsync(int agencyId, AddEditPropertyRequestModel model)
        {
            return HandleAsync(async (client) =>
            {
                var request = Mapping.Mapper.Map<AddPropertyRequest>(model, opt =>
                    opt.AfterMap((src, dest) => dest.AgencyId = agencyId));

                var response = await client.AddPropertyAsync(request);

                return response.Id;
            });
        }

        public Task<int> EditPropertyAsync(int agencyId, int id, AddEditPropertyRequestModel model)
        {
            return HandleAsync(async (client) =>
            {
                var request = Mapping.Mapper.Map<EditPropertyRequest>(model, opt =>
                    opt.AfterMap((src, dest) =>
                    {
                        dest.Id = id;
                        dest.AgencyId = agencyId;
                    }));

                var response = await client.EditPropertyAsync(request);

                return response.Id;
            });
        }

        public Task DeletePropertyAsync(int agencyId, int id)
        {
            return HandleAsync(async (client) =>
            {
                await client.DeletePropertyAsync(new DeletePropertyRequest { Id = id, AgencyId = agencyId });
            });
        }

        public Task<PropertyResponseModel> GetByIdAsync(int agencyId, int id)
        {
            return HandleAsync(async (client) =>
            {
                var property = await client.GetPropertyByIdAsync(new GetPropertyByIdRequest { Id = id, AgencyId = agencyId });

                return Mapping.Mapper.Map<PropertyResponseModel>(property);
            });
        }

        public Task<IEnumerable<PropertyResponseModel>> GetPropertiesAsync(int agencyId)
        {
            return HandleAsync<IEnumerable<PropertyResponseModel>>(async (client) =>
            {
                var properties = new List<PropertyResponseModel>();
                var request = new GetPropertiesRequest { AgencyId = agencyId };

                await foreach (var response in client.GetProperties(request).ResponseStream.ReadAllAsync())
                {
                    properties.Add(Mapping.Mapper.Map<PropertyResponseModel>(response));
                }

                return properties;
            });
        }

        protected override Property.PropertyClient CreateGrpcClient()
        {
            var channel = GetClientGrpcChannel(ServiceSettingsProvider.ComposePropertyServiceUrl());

            return new Property.PropertyClient(channel);
        }
    }
}
