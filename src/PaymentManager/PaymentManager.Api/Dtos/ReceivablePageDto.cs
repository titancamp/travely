using System.Collections.Generic;

namespace PaymentManager.Api.Dtos
{
    public class ReceivablePageDto
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public List<ReceivableReadDto> Items { get; set; }
    }
}
