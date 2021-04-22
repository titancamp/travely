using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using Travely.PropertyManager.API.Helpers;
using Travely.PropertyManager.API.Validators;
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
            RequestValidatorHelper.EnsureValidity<AddPropertyRequestValidator, AddPropertyRequest>(request);

            var command = _mapper.Map<AddPropertyRequest, AddPropertyCommand>(request);
            var resultId = await _propertyService.AddAsync(request.AgencyId, command);

            return new AddPropertyResponse { Id = resultId };
        }

        public override async Task<EditPropertyResponse> EditProperty(EditPropertyRequest request, ServerCallContext context)
        {
            RequestValidatorHelper.EnsureValidity<EditPropertyRequestValidator, EditPropertyRequest>(request);

            var command = _mapper.Map<EditPropertyRequest, EditPropertyCommand>(request);
            var resultId = await _propertyService.EditAsync(request.AgencyId, command);

            return new EditPropertyResponse { Id = resultId };
        }

        public override async Task<DeletePropertyResponse> DeleteProperty(DeletePropertyRequest request, ServerCallContext context)
        {
            await _propertyService.DeleteAsync(request.AgencyId, request.Id);

            return new DeletePropertyResponse();
        }

        public override async Task<GetPropertyByIdResponse> GetPropertyById(GetPropertyByIdRequest request, ServerCallContext context)
        {
            var result = await _propertyService.GetByIdAsync(request.AgencyId, request.Id);

            return _mapper.Map<GetPropertyByIdResponse>(result);
        }

        public override async Task GetProperties(GetPropertiesRequest request, IServerStreamWriter<GetPropertiesResponse> responseStream, ServerCallContext context)
        {
            var query = _mapper.Map<GetPropertiesRequest, GetPropertiesQuery>(request);
            var result = await _propertyService.GetAsync(request.AgencyId, query);

            foreach (var row in result)
            {
                await responseStream.WriteAsync(_mapper.Map<PropertyResponse, GetPropertiesResponse>(row));
            }
        }

        public override async Task GetRoomTypes(GetRoomTypesRequest request, IServerStreamWriter<GetRoomTypesResponse> responseStream, ServerCallContext context)
        {
            var result = await _propertyService.GetRoomTypesAsync();

            foreach (var row in result)
            {
                await responseStream.WriteAsync(_mapper.Map<RoomTypeResponse, GetRoomTypesResponse>(row));
            }
        }
    }
}
