using TechAndTools.Data;
using TechAndTools.Services.Contracts;

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
    }
}
