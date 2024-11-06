using DotNetApi.DTO;
using System.Threading.Tasks;

namespace DotNetApi.Interface
{
    public interface IOrders
    {
        Task<string> SaveOrders(OrderRequestDTO o);
        Task<List<PurchaseDetails>> GetPurchaseOrders(int customerid);
    }
}
