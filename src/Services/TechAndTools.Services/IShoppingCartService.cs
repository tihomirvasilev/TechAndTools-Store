using System.Linq;
using TechAndTools.Services.Models;

namespace TechAndTools.Services
{
    public interface IShoppingCartsService
    {
        void AddToShoppingCart(int productId, string username, int quantity);

        IQueryable<ShoppingCartProductServiceModel> GetAllShoppingCartProducts(string username);

        void DeleteProductFromShoppingCart(int id, string username);
    }
}
