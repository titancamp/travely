namespace Travely.SupplierManager.API.Models
{
    public class SupplierQueryParams
    {
        private const int MaxPageSize = 50;
        
        public int PageNumber { get; set; } = 1;
        
        private int _size = 20;
        
        public int Size
        {
            get => _size;
            set => _size = (value > MaxPageSize) ? MaxPageSize : value;
        }
        
        public string OrderBy { get; set; }
        public string Search { get; set; }
    }
}