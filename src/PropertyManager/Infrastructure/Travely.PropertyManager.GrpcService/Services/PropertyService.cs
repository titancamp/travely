using AutoMapper;
using Grpc.Core;
using System.Threading.Tasks;
using Travely.PropertyManager.Domain.Contracts;
using Travely.PropertyManager.Domain.Models.Commands;
using Travely.PropertyManager.Domain.Models.Queries;
using Travely.PropertyManager.Domain.Models.Responses;
using Travely.PropertyManager.GrpcService.Contracts;

namespace Travely.PropertyManager.GrpcService
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
