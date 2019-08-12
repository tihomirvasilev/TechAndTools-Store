using TechAndTools.Services.Models;

namespace TechAndTools.Services.Contracts
{
    public interface IOrderService
    {
        OrderServiceModel Create(OrderServiceModel orderServiceModel, string username, decimal deliveryPrice);
    }
}
