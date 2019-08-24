using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.ViewModels.Orders
{
    public class OrderProductViewModel : IMapFrom<OrderProductServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
