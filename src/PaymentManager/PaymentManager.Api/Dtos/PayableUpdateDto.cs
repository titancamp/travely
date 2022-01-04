using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaymentManager.Api.Dtos
{
    public class PayableUpdateDto
    {
        public decimal? ActualCost { get; set; }
        public DateTime? DueDate { get; set; }
        public List<PayableItemUpdateDto> PayableItems { get; set; }
        public string Note { get; set; }
    }
}