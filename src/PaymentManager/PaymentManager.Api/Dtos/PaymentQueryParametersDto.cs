namespace PaymentManager.Api.Dtos
{
    public class PaymentQueryParametersDto
    {
        public int Index { get; set; } = 1;
        public int Size { get; set; } = 10;
        public string OrderBy { get; set; }
        public string Search { get; set; }
    }
}
