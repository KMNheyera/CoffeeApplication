namespace CoffeeApplication.Dto
{
    public class PaymentDto
    {
        public string UserId { get; set; } = string.Empty;
        public List<CartDto> Products { get; set; } = new List<CartDto>();

    }

    public class CartDto
    {
        public string Id { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public int Qty { get; set; } = 0;
    }


}
