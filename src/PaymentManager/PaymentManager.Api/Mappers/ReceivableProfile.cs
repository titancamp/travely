using AutoMapper;
using PaymentManager.Api.Dtos;
using PaymentManager.Repositories.Entities;
using PaymentManager.Services.Models;
using PaymentManager.Shared;
using System;
using System.Linq;

namespace PaymentManager.Api.Mappers
{
    public class ReceivableProfile : Profile
    {
        public ReceivableProfile()
        {
            CreateMap<ReceivableRead, ReceivableReadDto>();
            CreateMap<ReceivableEntity, ReceivableRead>();
            CreateMap<ReceivableItem, ReceivableItemReadDto>();

            CreateMap<ReceivableCreate, ReceivableEntity>();

            CreateMap<ReceivableUpdateDto, ReceivableUpdate>();
            CreateMap<ReceivableUpdate, ReceivableEntity>()
                .ForMember(dst => dst.PaidAmount, opt => opt.MapFrom(src => src.ReceivableItems.Select(x => x.PaidAmount).DefaultIfEmpty(0).Sum()))
                .AfterMap((src, dst) => { dst.Remaining = dst.TotalAmount - dst.PaidAmount; })
                .AfterMap((src, dst) =>
                {
                    if (dst.TourStatus == TourStatus.Canceled && dst.PaidAmount == 0)
                    {
                        dst.Status = PaymentStatus.Canceled;
                    }
                    else if (dst.DueDate != null && DateTime.Compare(dst.DueDate.GetValueOrDefault(), DateTime.Now) < 0)
                    {
                        dst.Status = PaymentStatus.Overdue;
                    }
                    else if (dst.PaidAmount >= dst.TotalAmount)
                    {
                        dst.Status = PaymentStatus.FullyPaid;
                    }
                    else if (dst.PaidAmount > 0)
                    {
                        dst.Status = PaymentStatus.PartiallyPaid;
                    }
                    else
                    {
                        dst.Status = PaymentStatus.Unpaid;
                    }
                });
            CreateMap<ReceivableItemEntity, ReceivableItem>();
            CreateMap<ReceivableItem, ReceivableItemEntity>();
            CreateMap<ReceivableItemUpdateDto, ReceivableItem>();

            CreateMap<PaymentQueryParametersDto, PaymentQueryParameters>();
            CreateMap<ReceivablePage, ReceivablePageDto>();
        }
    }
}