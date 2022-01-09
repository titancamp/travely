using AutoMapper;
using PaymentManager.Api.Dtos;
using PaymentManager.Repositories.Entities;
using PaymentManager.Services.Models;
using PaymentManager.Shared;
using System;
using System.Linq;

namespace PaymentManager.Api.Mappers
{
    public class PayableProfile : Profile
    {
        public PayableProfile()
        {
            CreateMap<PayableRead, PayableReadDto>();
            CreateMap<PayableRead, PayableReadDetailedDto>();
            CreateMap<PayableEntity, PayableRead>();
            CreateMap<PayableItem, PayableItemReadDto>();

            CreateMap<PayableCreate, PayableEntity>();

            CreateMap<PayableUpdateDto, PayableUpdate>();
            CreateMap<PayableUpdate, PayableEntity>()
                .ForMember(dst => dst.HasAttachment, opt => opt.MapFrom(src => src.PayableItems.Any(i => i.AttachmentId != null)))
                .ForMember(dst => dst.PaymentDate, opt => opt.MapFrom(src => src.PayableItems.DefaultIfEmpty(null).Max(x => x.PaymentDate)))
                .ForMember(dst => dst.PaidAmount, opt => opt.MapFrom(src => src.PayableItems.Select(x => x.PaidAmount).DefaultIfEmpty(0).Sum()))
                .AfterMap((src, dst) => { dst.Difference = dst.PlannedCost - src?.ActualCost; })
                .AfterMap((src, dst) => { dst.Remaining = src?.ActualCost - dst.PaidAmount; })
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
                    else if (dst.ActualCost != null && dst.PaidAmount >= dst.ActualCost)
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
                    if (!src.PayableItems.Any())
                    {
                        dst.PaymentType = null;
                    }
                    else if (src.PayableItems.Select(i => i.PaymentType).Count() == 1)
                    {
                        dst.PaymentType = src.PayableItems[0].PaymentType;
                    }
                    else
                    {
                        dst.PaymentType = PaymentType.Mixed;
                    }
                });
            CreateMap<PayableItemEntity, PayableItem>();
            CreateMap<PayableItem, PayableItemEntity>();
            CreateMap<PayableItemUpdateDto, PayableItem>();

            CreateMap<PaymentQueryParametersDto, PaymentQueryParameters>();
            CreateMap<PayablePage, PayablePageDto>();
        }
    }
}