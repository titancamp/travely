using System;
using System.Collections.Generic;

namespace PaymentManager.Api.Dtos
{
    public class PayableUpdateDto
    {
        public decimal? ActualCost { get; set; } = null;
        public DateTime? DueDate { get; set; } = null;
        public List<PayableItemUpdateDto> PayableItems { get; set; }
    }
}