using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services.Models;

namespace TechAndTools.Services.Contracts
{
    public interface IOrderService
    {
        OrderServiceModel Create(OrderServiceModel orderServiceModel, string username, decimal deliveryPrice);

        OrderServiceModel GetOrderById(int orderId);

        Task<bool> ProcessOrderAsync(int id);

        Task<bool> DeliverOrderAsync(int id);

        IQueryable<OrderServiceModel> GetAllOrdersByUserId(string userId);

        IQueryable<OrderServiceModel> GetUnprocessedOrders();

        IQueryable<OrderServiceModel> GetProcessedOrders();

        IQueryable<OrderServiceModel> GetDeliveredOrders();
    }
}
