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
            CreateMap<PayableEntity, PayableRead>();
            CreateMap<PayableItem, PayableItemReadDto>();

            CreateMap<PayableCreate, PayableEntity>();

            CreateMap<PayableUpdateDto, PayableUpdate>();
            CreateMap<PayableUpdate, PayableEntity>()
                .ForMember(x => x.Paid, opt => opt.MapFrom(src => src.PayableItems.Select(x => x.PaidAmount).DefaultIfEmpty(0).Sum()))
                .AfterMap((src, dst) =>
                {
                    if (dst.ActualCost == null)
                    {
                        dst.Difference = null;
                    }
                    else
                    {
                        dst.Difference = dst.PlannedCost - src.ActualCost;
                    }
                })
                .AfterMap((src, dst) =>
                {
                    if (dst.ActualCost == null)
                    {
                        dst.Remaining = null;
                    }
                    dst.Remaining = dst.ActualCost - dst.Paid;
                })
                .AfterMap((src, dst) =>
                {
                    if (dst.TourStatus == TourStatus.Deleted)
                    {
                        dst.Status = PaymentStatus.Canceled;
                    }
                    else if (dst.DueDate != null && DateTime.Compare(dst.DueDate.GetValueOrDefault(), DateTime.Now) < 0)
                    {
                        dst.Status = PaymentStatus.Overdue;
                    }
                    else if (dst.ActualCost != null && dst.Paid >= dst.ActualCost)
                    {
                        dst.Status = PaymentStatus.FullyPaid;
                    }
                    else if (dst.Paid > 0)
                    {
                        dst.Status = PaymentStatus.PartiallyPaid;
                    }
                    else
                    {
                        dst.Status = PaymentStatus.Unpaid;
                    }
                });
            CreateMap<PayableItemEntity, PayableItem>();
            CreateMap<PayableItem, PayableItemEntity>();
            CreateMap<PayableItemUpdateDto, PayableItem>();

            CreateMap<PayableQueryParametersDto, PayableQueryParameters>();
            CreateMap<PayablePage, PayablePageDto>();
        }
    }
}