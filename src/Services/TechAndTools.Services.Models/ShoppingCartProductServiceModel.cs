using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class ShoppingCartProductServiceModel : IMapFrom<ShoppingCartProduct>, IMapTo<ShoppingCartProduct>
    {
        public int ShoppingCardId { get; set; }
        public ShoppingCartServiceModel ShoppingCart { get; set; }

        public int ProductId { get; set; }
        public ProductServiceModel Product { get; set; }

        public int Quantity { get; set; }
    }
}
