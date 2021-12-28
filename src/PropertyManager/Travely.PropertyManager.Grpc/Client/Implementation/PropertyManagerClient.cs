using AutoMapper;
using Grpc.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.Common.Grpc;
using Travely.Common.Grpc.Abstraction;
using Travely.PropertyManager.Grpc.Client.Abstraction;
using Travely.PropertyManager.Grpc.Models;

namespace Travely.PropertyManager.Grpc.Client.Implementation
{
    public class PropertyManagerClient : GrpcClientBase<Property.PropertyClient>, IPropertyManagerClient
    {
        private readonly IMapper _mapper;

        public PropertyManagerClient(
            IServiceSettingsProvider<Property.PropertyClient> serviceSettingsProvider,
            IMapper mapper)
            : base(serviceSettingsProvider)
        {
            _mapper = mapper;
        }

        public Task<int> AddPropertyAsync(int agencyId, AddEditPropertyRequestModel model)
        {
            return HandleAsync(async (client) =>
            {
                var request = _mapper.Map<AddPropertyRequest>(model, opt =>
                    opt.AfterMap((src, dest) => dest.AgencyId = agencyId));

                var response = await client.AddPropertyAsync(request);

                return response.Id;
            });
        }

        public Task<int> EditPropertyAsync(int agencyId, int id, AddEditPropertyRequestModel model)
        {
            return HandleAsync(async (client) =>
            {
                var request = _mapper.Map<EditPropertyRequest>(model, opt =>
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

                return _mapper.Map<PropertyResponseModel>(property);
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
                    properties.Add(_mapper.Map<PropertyResponseModel>(response));
                }

                return properties;
            });
        }
    }
}
