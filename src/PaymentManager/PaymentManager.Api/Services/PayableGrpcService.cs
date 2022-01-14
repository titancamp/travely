using AutoMapper;
using Grpc.Core;
using PaymentManager.Services;
using PaymentManager.Services.Models;
using PaymentManager.Shared;
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

                var payableRead = await _payableService.CreateAsync(payable.AgencyId, payableCreate);

                await responseStream.WriteAsync(new CreatePaymentResponse() { Id = payableRead.Id});
            }
        }

        public override async Task<PayableResponse> UpdatePaymentSupplier(SupplierUpdate request, ServerCallContext context)
        {
            var updateModel = _mapper.Map<PayableSupplierUpdate>(request);

            await _payableService.UpdateSupplier(request.AgencyId, request.PayableId, updateModel);

            return new PayableResponse();
        }

        public override async Task GetPayablesByTourId(TourModel request, IServerStreamWriter<PayablesByTourIdModel> responseStream, ServerCallContext context)
        {
            var payables = new List<PayablesByTourIdModel>();
            foreach (var tourId in request.TourIds)
            {
                var response = _payableService.Find(m => m.TourId == tourId && m.AgencyId == request.AgencyId);
                var responseModel = _mapper.Map<List<PayableReadModel>>(response);
                var payablesByTour = new PayablesByTourIdModel() { TourId = tourId};
                payablesByTour.Payables.AddRange(responseModel);
                await responseStream.WriteAsync(payablesByTour);
            }
        }

        public override async Task GetPayablesByAgencyId(Agency request, IServerStreamWriter<PayableReadModel> responseStream, ServerCallContext context)
        {
            var response = _payableService.Get(request.AgencyId, new PaymentQueryParameters() { Index = request.Page, Size = request.Size});
            var responseModel = _mapper.Map<List<PayableReadModel>>(response.Items);
            foreach (var payable in responseModel)
            {
                await responseStream.WriteAsync(payable);
            }
        }

        public override async Task<PayableReadModel> GetPayableByTourIdAndSupplierId(GetPayableModel request, ServerCallContext context)
        {
            var response = await _payableService.Find(m => m.AgencyId == request.AgencyId && m.TourId == request.TourId && m.SupplierId == request.SupplierId);
            if (response.Count != 1)
            {
                throw new Exception(); //TODO need to clarify how we manage exceptions.
            }

            return _mapper.Map<PayableReadModel>(response[0]);
        }

        public override async Task<PayableResponse> UpdateTourStatus(UpdateTourStatusModel request, ServerCallContext context)
        {
            await _payableService.UpdatePayablesTourStatus(request.AgencyId, request.TourId, request.TourStatus);

            return new PayableResponse();
        }

        public override async Task<PayableResponse> DeleteSupplierFromPayable(DeleteSupplierModel request, ServerCallContext context)
        {
            await _payableService.DeleteSupplierFromPayable(request.AgencyId, request.TourId, request.SupplierId);

            return new PayableResponse();
        }
    }
}
