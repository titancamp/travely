using AutoMapper;
using PaymentManager.Grpc.Models;
using Travely.PaymentManager.Grpc;

namespace PaymentManager.Grpc.Mappers
{
    public class PayableProfile : Profile
    {
        public PayableProfile()
        {
            CreateMap<AddPaymentModel, PayableCreateModel>();
            CreateMap<UpdateSupplierModel, SupplierUpdate>();
            CreateMap<TourEntity, TourModel>();
            CreateMap<Agency, AgencyEntity>();
            CreateMap<PayableReadModel, PayableReadEntity>();
            CreateMap<PayablesByTourIdModel, PayablesByTourIdEntity>();
            CreateMap<PayablesByAgencyEntity, Agency>();
        }
    }
}
