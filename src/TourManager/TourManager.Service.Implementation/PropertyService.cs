using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TourManager.Clients.Abstraction.PropertyManager;
using TourManager.Repository.Abstraction;
using TourManager.Repository.Entities;
using TourManager.Service.Abstraction;
using TourManager.Service.Model.PropertyManager;

namespace TourManager.Service.Implementation
{
    public class PropertyService : IPropertyService
    {
        private readonly IMapper _mapper;
        private readonly IPropertyManagerClient _client;
        private readonly IPropertyRepository _repository;

        public PropertyService(IMapper mapper, IPropertyManagerClient client, IPropertyRepository repository)
        {
            _mapper = mapper;
            _client = client;
            _repository = repository;
        }

        public async Task<int> AddAsync(int agencyId, AddEditPropertyRequestModel request)
        {
            var id = await _client.AddPropertyAsync(agencyId, request);

            var model = _mapper.Map<AddEditPropertyRequestModel, PropertyEntity>(request);

            model.Id = id;
            model.AgencyId = agencyId;

            await _repository.Add(model);

            return id;
        }

        public async Task<int> EditAsync(int agencyId, int id, AddEditPropertyRequestModel request)
        {
            var propertyId = await _client.EditPropertyAsync(agencyId, id, request);

            var model = _mapper.Map<AddEditPropertyRequestModel, PropertyEntity>(request);

            model.Id = propertyId;
            model.AgencyId = agencyId;

            await _repository.Update(model);

            return propertyId;
        }


        public async Task DeleteAsync(int agencyId, int id)
        {
            var property = await _repository.GetById(id);

            if (property == null || property.AgencyId != agencyId)
            {
                throw new ArgumentException("Hotel not found");
            }

            await _client.DeletePropertyAsync(agencyId, id);


            await _repository.Remove(property);
        }

        public Task<PropertyResponseModel> GetByIdAsync(int agencyId, int id)
        {
            return _client.GetByIdAsync(agencyId, id);
        }

        public Task<IEnumerable<PropertyResponseModel>> GetAsync(int agencyId)
        {
            return _client.GetPropertiesAsync(agencyId);
        }

        public Task<IEnumerable<RoomTypeResponseModel>> GetRoomTypesAsync()
        {
            return _client.GetRoomTypesAsync();
        }
    }
}
