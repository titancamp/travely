using AutoMapper;
using Grpc.Core;
using PaymentManager.Services;
using PaymentManager.Services.Models;
using System;
using System.Collections.Generic;
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

        public override async Task<ReseivableResponseModel> CreateReceivable(CreateReceivableModel request, ServerCallContext context)
        {
            var createModel = _mapper.Map<ReceivableCreate>(request);

            var responseModel = await _receivableService.CreateAsync(request.AgencyId, createModel);

            return new ReseivableResponseModel();
        }

        public override async Task<ReceivableReadModel> GetReceivableTourId(TourReceivable request, ServerCallContext context)
        {
            var responseModel = await _receivableService.Find(m => m.AgencyId == request.AgencyId && m.TourId == request.TourId);
            if (responseModel.Count != 1)
            {
                throw new Exception(); //TODO need to clarify how we manage exceptions.
            }

            var receivableModel = _mapper.Map<ReceivableReadModel>(responseModel);


            return receivableModel;
        }

        public override async Task GetReceivablesByAgencyId(Agency request, IServerStreamWriter<ReceivableReadModel> responseStream, ServerCallContext context)
        {
            var response = _receivableService.Get(request.AgencyId, new PaymentQueryParameters() { Index = request.Page, Size = request.Size });
            var receivableModel = _mapper.Map<List<ReceivableReadModel>>(response.Items);
            foreach (var receivable in receivableModel)
            {
                await responseStream.WriteAsync(receivable);
            }
        }
    }
}
