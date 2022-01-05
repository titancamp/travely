using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaymentManager.Api.Dtos
{
    public class ReceivableUpdateDto
    {
        public DateTime? DueDate { get; set; }
        public List<ReceivableItemUpdateDto> ReceivableItems { get; set; }
        public string Note { get; set; }
    }
}