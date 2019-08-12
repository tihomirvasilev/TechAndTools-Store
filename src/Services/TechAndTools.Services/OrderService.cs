using System.Linq;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Services
{
    public class OrderService : IOrderService
    {
        
        private readonly IUserService userService;
        private readonly IShoppingCartService shoppingCartService;
        private readonly TechAndToolsDbContext context;

        public OrderService(IUserService userService, IShoppingCartService shoppingCartService, TechAndToolsDbContext context)
        {
            this.userService = userService;
            this.shoppingCartService = shoppingCartService;
            this.context = context;
        }

        public OrderServiceModel Create(OrderServiceModel orderServiceModel, string username, decimal deliveryPrice)
        {
            var user = this.userService.GetUserByUsername(username);

            var order = orderServiceModel.To<Order>();

            ;

            this.context.Orders.Add(order);
            this.context.SaveChanges();

            return order.To<OrderServiceModel>();
        }
    }
}
