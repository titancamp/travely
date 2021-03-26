﻿using AutoMapper;
using Grpc.Core;
using System.Threading.Tasks;
using Travely.PropertyManager.Service.Contracts;
using Travely.PropertyManager.Service.Models.Commands;
using Travely.PropertyManager.Service.Models.Queries;
using Travely.PropertyManager.Service.Models.Responses;

namespace Travely.PropertyManager.API.Services
{
    public class PropertyService : Property.PropertyBase
    {
        private readonly IMapper _mapper;
        private readonly IPropertyService _propertyService;

        public PropertyService(IMapper mapper, IPropertyService propertyService)
        {
            _mapper = mapper;
            _propertyService = propertyService;
        }

        public override async Task<AddPropertyResponse> AddProperty(AddPropertyRequest request, ServerCallContext context)
        {
            var command = _mapper.Map<AddPropertyRequest, AddPropertyCommand>(request);
            var resultId = await _propertyService.AddAsync(command);

            return new AddPropertyResponse { Id = resultId };
        }

        public override async Task<DeletePropertyResponse> DeleteProperty(DeletePropertyRequest request, ServerCallContext context)
        {
            await _propertyService.DeleteAsync(request.Id);

            return new DeletePropertyResponse();
        }

        public override async Task<GetPropertyByIdResponse> GetPropertyById(GetPropertyByIdRequest request, ServerCallContext context)
        {
            var result = await _propertyService.GetByIdAsync(request.Id);

            return _mapper.Map<GetPropertyByIdResponse>(result);
        }

        public override async Task GetProperties(GetPropertiesRequest request, IServerStreamWriter<GetPropertiesResponse> responseStream, ServerCallContext context)
        {
            var query = _mapper.Map<GetPropertiesRequest, GetPropertiesQuery>(request);
            var result = await _propertyService.GetAsync(query);

            foreach (var row in result)
            {
                await responseStream.WriteAsync(_mapper.Map<PropertyResponse, GetPropertiesResponse>(row));
            }
        }
    }

}
