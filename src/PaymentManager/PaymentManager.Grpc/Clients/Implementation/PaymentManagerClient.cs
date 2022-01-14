using AutoMapper;
using Grpc.Core;
using PaymentManager.Grpc.Clients.Abstraction;
using PaymentManager.Grpc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.Common.Grpc;
using Travely.Common.Grpc.Abstraction;
using Travely.PaymentManager.Grpc;

namespace PaymentManager.Grpc.Clients.Implementation
{
    public class PaymentManagerClient : GrpcClientBase<PaymentProto.PaymentProtoClient>, IPaymentManagerClient
    {
        private readonly IMapper _mapper;

        public PaymentManagerClient(
            IServiceSettingsProvider<PaymentProto.PaymentProtoClient> serviceSettingsProvider,
            IMapper mapper)
            : base(serviceSettingsProvider)
        {
            _mapper = mapper;
        }

        public Task<List<int>> AddPayableAsync(int agencyId, IEnumerable<AddPaymentModel> model)
        {
            return HandleAsync(async (client) =>
            {
                var request = _mapper.Map<List<PayableCreateModel>>(model, opt =>
                    opt.AfterMap((src, dest) =>
                    {
                        foreach (var item in dest)
                        {
                            item.AgencyId = agencyId;
                        }
                    }));

                var payableResponses = new List<int>();

                using AsyncDuplexStreamingCall<PayableCreateModel, CreatePaymentResponse> stream =
                    client.CreatePayment();
                foreach (var payable in request)
                {
                    await stream.RequestStream.WriteAsync(payable);
                }

                await stream.RequestStream.CompleteAsync(); // need to check this.


                await foreach (var payableResponse in stream.ResponseStream.ReadAllAsync())
                {
                    payableResponses.Add(payableResponse.Id);
                }

                return payableResponses;
            });
        }

        public Task<List<PayableReadEntity>> GetPayablesByAgencyId(PayablesByAgencyEntity model)
        {
            return HandleAsync(async (client) =>
            {
                var requestModel = _mapper.Map<Agency>(model);

                var payablesResponses = client.GetPayablesByAgencyId(requestModel);
                var payables = new List<PayableReadEntity>();

                await foreach (var payableResponse in payablesResponses.ResponseStream.ReadAllAsync())
                {
                    var payableEntity = _mapper.Map<PayableReadEntity>(payableResponse);
                    payables.Add(payableEntity);
                }

                return payables;
            });
        }

        public Task<List<PayablesByTourIdEntity>> GetPayablesByTourId(int agencyId, TourEntity model)
        {
            return HandleAsync(async (client) =>
            {
                var requestModel = _mapper.Map<TourModel>(model, opt => opt.AfterMap((src, dest) =>
                {
                    dest.AgencyId = agencyId;
                }));

                var payablesResponses = client.GetPayablesByTourId(requestModel);
                var payables = new List<PayablesByTourIdEntity>();

                await foreach (var payableResponse in payablesResponses.ResponseStream.ReadAllAsync())
                {
                    var payableEntity = _mapper.Map<PayablesByTourIdEntity>(payableResponse);
                    payables.Add(payableEntity);
                }

                return payables;
            });
        }

        public Task<SupplierUpdateResponseModel> UpdateSupplierAsync(int agencyId, int id, UpdateSupplierModel model)
        {
            return HandleAsync(async (client) =>
            {
                var updateRequest = _mapper.Map<SupplierUpdate>(model, opt => opt.AfterMap((src, dest) =>
                {
                    dest.AgencyId = agencyId;
                    dest.PayableId = id;    
                }));

                var response = await client.UpdatePaymentSupplierAsync(updateRequest);

                return _mapper.Map<SupplierUpdateResponseModel>(response);
            });
        }
    }
}
