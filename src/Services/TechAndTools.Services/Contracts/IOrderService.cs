using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services.Models;

namespace TechAndTools.Services.Contracts
{
    public interface IOrderService
    {
        OrderServiceModel Create(OrderServiceModel orderServiceModel, string username, decimal deliveryPrice);

        OrderServiceModel GetOrderById(int orderId);

        Task<bool> ProcessOrder(int id);

        Task<bool> DeliverOrder(int id);

        IQueryable<OrderServiceModel> GetAllOrdersByUserId(string userId);

        IQueryable<OrderServiceModel> GetUnprocessedOrders();

        IQueryable<OrderServiceModel> GetProcessedOrders();
    }
}
