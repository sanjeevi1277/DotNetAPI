using DotNetApi.DTO;
using DotNetApi.Interface;
using System.Threading.Tasks;

namespace DotNetApi.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrders _orderService;
        public OrderController(IOrders order)
        {
            _orderService = order;

        }
        [HttpPost("saveorders")]

        public async Task<string> SaveOrders(OrderRequestDTO o)
        {

            var result = await _orderService.SaveOrders(o);
            return result;
        }
        [HttpGet("getPurchaseOrders")]
        public async Task<List<PurchaseDetails>> GetPurchaseOrders(int customerid)
        {
            var res = await _orderService.GetPurchaseOrders(customerid);
            return res;
        }
    }
}
