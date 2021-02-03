using AutoMapper;
using Grpc.Core;
using System.Linq;
using System.Threading.Tasks;
using Travely.PropertyManager.Domain.Contracts.Models.Commands;
using Travely.PropertyManager.Domain.Contracts.Models.Queries;
using Travely.PropertyManager.Domain.Contracts.Models.Responses;
using Travely.PropertyManager.Domain.Contracts.Services;
using Travely.PropertyManager.GrpcService.Contracts;

namespace Travely.PropertyManager.GrpcService
{
    public class PropertyTypeService : PropertyType.PropertyTypeBase
    {
        private readonly IMapper _mapper;
        private readonly IPropertyTypeService _propertyTypeService;

        public PropertyTypeService(IMapper mapper, IPropertyTypeService propertyTypeService)
        {
            _mapper = mapper;
            _propertyTypeService = propertyTypeService;
        }

        public override async Task<AddPropertyTypeResponse> AddPropertyType(AddPropertyTypeRequest request, ServerCallContext context)
        {
            var model = _mapper.Map<AddPropertyTypeRequest, AddPropertyTypeCommand>(request);
            await _propertyTypeService.AddAsync(model);

            return new AddPropertyTypeResponse();
        }


        public override async Task<GetPropertyTypeResponse> GetPropertyTypeById(GetPropertyTypeByIdRequest request, ServerCallContext context)
        {
            var model = await _propertyTypeService.GetByIdAsync(request.Id);

            return _mapper.Map<PropertyTypeResponse, GetPropertyTypeResponse>(model);
        }

        public override async Task GetPropertyTypes(GetPropertyTypesRequest request, IServerStreamWriter<GetPropertyTypeResponse> responseStream, ServerCallContext context)
        {
            var model = _mapper.Map<GetPropertyTypesRequest, GetPropertyTypesQuery>(request);

            var result = (await _propertyTypeService.GetAsync(model))
                        .Select(row => _mapper.Map<PropertyTypeResponse, GetPropertyTypeResponse>(row));

            foreach(var row in result)
            { 
                await responseStream.WriteAsync(row);
            }
        }
    }

}
