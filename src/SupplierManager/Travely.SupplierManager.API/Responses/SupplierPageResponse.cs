using System.Collections.Generic;

namespace Travely.SupplierManager.API.Responses
{
    public class SupplierPageResponse<TModel>
    {
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        
        public List<TModel> Items { get; private set; }
    }
}