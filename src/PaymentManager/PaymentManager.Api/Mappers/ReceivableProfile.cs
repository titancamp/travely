using AutoMapper;
using PaymentManager.Api.Dtos;
using PaymentManager.Repositories.Entities;
using PaymentManager.Services.Models;
using PaymentManager.Shared;
using System;
using System.Linq;
using PaymentManager.Repositories.Filters;
using PaymentManager.Repositories.Models;

namespace PaymentManager.Api.Mappers
{
    public class ReceivableProfile : Profile
    {
        public ReceivableProfile()
        {
            CreateMap<ReceivableRead, ReceivableReadDto>();
            CreateMap<ReceivableRead, ReceivableReadDetailedDto>();
            CreateMap<ReceivableEntity, ReceivableRead>();
            CreateMap<ReceivableItem, ReceivableItemReadDto>();

            CreateMap<ReceivableCreate, ReceivableEntity>();

            CreateMap<ReceivableUpdateDto, ReceivableUpdate>();
            CreateMap<ReceivableUpdate, ReceivableEntity>()
                .ForMember(dst => dst.HasAttachment, opt => opt.MapFrom(src => src.ReceivableItems.Any(i => i.AttachmentId != null)))
                .ForMember(dst => dst.PaymentDate, opt => opt.MapFrom(src => src.ReceivableItems.DefaultIfEmpty(null).Max(x => x.PaymentDate)))
                .ForMember(dst => dst.PaidAmount, opt => opt.MapFrom(src => src.ReceivableItems.Select(x => x.PaidAmount).DefaultIfEmpty(0).Sum()))
                .ForMember(dst => dst.InvoiceSent, opt => opt.MapFrom(src => src.ReceivableItems.All(i => i.InvoiceSent)))
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
                })
                .AfterMap((src, dst) =>
                {
                    if (!src.ReceivableItems.Any())
                    {
                        dst.PaymentType = null;
                    }
                    else if (src.ReceivableItems.Select(i => i.PaymentType).Count() == 1)
                    {
                        dst.PaymentType = src.ReceivableItems[0].PaymentType;
                    }
                    else
                    {
                        dst.PaymentType = PaymentType.Mixed;
                    }
                });
            CreateMap<ReceivableItemEntity, ReceivableItem>();
            CreateMap<ReceivableItem, ReceivableItemEntity>();
            CreateMap<ReceivableItemUpdateDto, ReceivableItem>();

            CreateMap<PaymentQueryParametersDto, PaymentQueryParameters>();
            CreateMap<ReceivableFilterDto, ReceivableFilter>();
            CreateMap<ReceivablePage, ReceivablePageDto>();
        }
    }
}