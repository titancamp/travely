using AutoMapper;
using Grpc.Core;
using PaymentManager.Services;
using System.Threading.Tasks;
using Travely.PaymentManager.Grpc;

namespace PaymentManager.Api.Services
{
    public class ReceivableGrpcService : ReceivableProto.ReceivableProtoBase
    {
        private readonly IMapper _mapper;
        private readonly IReceivableService _receivableService;

        public ReceivableGrpcService(IMapper mapper, IReceivableService receivableService)
        {
            _mapper = mapper;
            _receivableService = receivableService;
        }

        public override Task<ReseivableResponseModel> CreateReceivable(CreateReceivableModel request, ServerCallContext context)
        {
            return base.CreateReceivable(request, context);
        }

        public override Task<ReceivableReadModel> GetReceivableTourId(TourReceivable request, ServerCallContext context)
        {
            return base.GetReceivableTourId(request, context);
        }

        public override Task GetReceivablesByAgencyId(AgencyModel request, IServerStreamWriter<ReceivableReadModel> responseStream, ServerCallContext context)
        {
            return base.GetReceivablesByAgencyId(request, responseStream, context);
        }
    }
}
