using DotNetApi.Enum;

namespace DotNetApi.DTO
{
    public class PurchaseDetails
    {
        public double TotalAmount { get; set; } // Total amount for the entire order

        public OrderStatus OrderStatus { get; set; } // Enum type for order status
        public DateTime OrderedDate { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }

    }
    public class OrderDetailDto
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public double Amount { get; set; }
        public int Quantity { get; set; }
    }
}
