using System.Linq;
using TechAndTools.Services.Models;

namespace TechAndTools.Services.Contracts
{
    public interface IShoppingCartService
    {
        void AddToShoppingCart(int productId, string username, int quantity);

        IQueryable<ShoppingCartProductServiceModel> GetAllShoppingCartProducts(string username);

        void DeleteProductFromShoppingCart(int id, string username);
        bool AnyProducts(string username);
        bool DeleteAllProductFromShoppingCart(string username);
    }
}
