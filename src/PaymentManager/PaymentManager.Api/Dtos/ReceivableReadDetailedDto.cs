using PaymentManager.Shared;
using System;
using System.Collections.Generic;

namespace PaymentManager.Api.Dtos
{
    public class ReceivableReadDetailedDto : ReceivableReadDto
    {
        public List<ReceivableItemReadDto> ReceivableItems { get; set; }
        public string Note { get; set; }
    }
}
