using System.Linq;
using TechAndTools.Services.Models;

namespace TechAndTools.Services.Contracts
{
    public interface IOrderService
    {
        OrderServiceModel Create(OrderServiceModel orderServiceModel, string username, decimal deliveryPrice);

        OrderServiceModel GetOrderById(int orderId);

        IQueryable<OrderServiceModel> GetAllOrdersByUserId(string userId);

        IQueryable<OrderServiceModel> GetUnprocessedOrders();

        IQueryable<OrderServiceModel> GetProcessedOrders();
    }
}
