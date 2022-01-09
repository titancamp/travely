using AutoMapper;
using Grpc.Core;
using PaymentManager.Services;
using PaymentManager.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Travely.PaymentManager.Grpc;

namespace PaymentManager.Api.Services
{
    public class PayableGrpcService : PaymentProto.PaymentProtoBase
    {
        private readonly IPayableService _payableService;
        private readonly IMapper _mapper;

        public PayableGrpcService(IPayableService payableService, IMapper mapper)
        {
            _payableService = payableService;
            _mapper = mapper;
        }

        public override async Task CreatePayment(IAsyncStreamReader<PayableCreateModel> requestStream, IServerStreamWriter<CreatePaymentResponse> responseStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                var payable = requestStream.Current;

                var payableCreate = _mapper.Map<PayableCreate>(payable);

                var payableRead = await _payableService.Create(payable.AgencyId, payableCreate);

                await responseStream.WriteAsync(new CreatePaymentResponse() { Id = payableRead.Id});
            }
        }

        public override async Task<CreatePaymentResponse> UpdatePaymentSupplier(SupplierUpdate request, ServerCallContext context)
        {
            var updateModel = _mapper.Map<PayableUpdate>(request);

            var updateResponse = await _payableService.Update(request.AgencyId, request.PayableId, updateModel);

            return _mapper.Map<CreatePaymentResponse>(updateResponse);  
        }

        public override async Task GetPayablesByTourId(TourModel request, IServerStreamWriter<PayablesByTourIdModel> responseStream, ServerCallContext context)
        {
            var payables = new List<PayablesByTourIdModel>();
            foreach (var tourId in request.TourIds)
            {
                var response = _payableService.Find(request.AgencyId, tourId);
                var responseModel = _mapper.Map<List<PayableReadModel>>(response);
                var payablesByTour = new PayablesByTourIdModel() { TourId = tourId};
                payablesByTour.Payables.AddRange(responseModel);
                await responseStream.WriteAsync(payablesByTour);
            }
        }

        public override async Task GetPayablesByAgencyId(Agency request, IServerStreamWriter<PayableReadModel> responseStream, ServerCallContext context)
        {
            var response = _payableService.Get(request.AgencyId, new PaymentQueryParameters() { Index = request.Page, Size = request.Size});
            var responseModel = _mapper.Map<List<PayableReadModel>>(response.Result.Items);
            foreach (var payable in responseModel)
            {
                await responseStream.WriteAsync(payable);
            }
        }
    }
}
