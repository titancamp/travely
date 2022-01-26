using PaymentManager.Shared;
using System;
using System.Collections.Generic;

namespace PaymentManager.Api.Dtos
{
    public class PayableReadDetailedDto : PayableReadDto
    {
        public List<PayableItemReadDto> PayableItems { get; set; }
        public string Note { get; set; }
    }
}
