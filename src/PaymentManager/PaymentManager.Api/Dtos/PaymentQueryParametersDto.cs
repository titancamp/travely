using System.ComponentModel.DataAnnotations;

namespace PaymentManager.Api.Dtos
{
    public class PaymentQueryParametersDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be bigger than {1}")]
        public int Index { get; set; } = 1;
        [Range(10, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Size { get; set; } = 20;
        public string OrderBy { get; set; }
        public string Search { get; set; }
    }
}
