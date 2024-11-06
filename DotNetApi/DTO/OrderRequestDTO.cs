namespace DotNetApi.DTO
{
    public class OrderRequestDTO
    {
        public int UserId { get; set; }
        public double TotalAmount { get; set; }
        public int OrderStatus { get; set; }
        public int TotalQuantity { get; set; }
        public List<OrderDetailsDTO> OrderDetailsDTO { get; set; }

    }

    public class OrderDetailsDTO
    {
        public int OrderId { get; set; }
        public double Amount { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }

    }
}
