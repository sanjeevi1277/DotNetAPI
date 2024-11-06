using DotNetApi.DTO;
using DotNetApi.Enum;
using DotNetApi.Interface;
using DotNetApi.Model.Data;
using DotNetApi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DotNetApi.Repository
{
    public class OrderService : IOrders
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext dbContext)
        {
            _context = dbContext;

        }
        public async Task<string> SaveOrders(OrderRequestDTO o)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            Order order = new Order();

            order.UserId = o.UserId;
            order.TotalQuantity = o.TotalQuantity;
            order.TotalAmount = o.TotalAmount;
            order.OrderStatus = o.OrderStatus;
            _context.Order.Add(order);
            _context.SaveChanges();

            foreach (var orderdetails in o.OrderDetailsDTO)
            {
                OrderDetails od = new OrderDetails
                {
                    OrderId = order.Id,
                    Amount = orderdetails.Amount,
                    Quantity = orderdetails.Quantity,
                    ProductId = orderdetails.ProductId,

                };

                _context.OrderDetails.Add(od);

            }
            _context.SaveChanges();
            //await transaction.CommitAsync();
            //await transaction.RollbackAsync();

            return "Order Created Successfully!";


        }
        public Task<List<PurchaseDetails>> GetPurchaseOrders(int customerid)
        {
            var purchaseDetailsList = _context.Order
        .Where(o => o.UserId == customerid)
        .Select(o => new PurchaseDetails
        {
            TotalAmount = o.TotalAmount, // TotalAmount from Order
            OrderStatus = (OrderStatus)o.OrderStatus,
            OrderedDate = o.OrderedDate,   // Assuming you have a CreatedOn field for the order date
            OrderDetails = o.OrderDetails.Select(od => new OrderDetailDto
            {
                ProductName = od.Product.ProductName,
                CategoryName = od.Product.Category.Name,
                Amount = od.Amount,
                Quantity = od.Quantity
            }).ToList()
        })
        .ToListAsync();

            return purchaseDetailsList;

        }


    }
}
