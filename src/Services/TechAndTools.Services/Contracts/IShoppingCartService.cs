using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services.Models;

namespace TechAndTools.Services.Contracts
{
    public interface IShoppingCartService
    {
        Task<ShoppingCartProductServiceModel> AddToShoppingCartAsync(int productId, string username, int quantity);

        IQueryable<ShoppingCartProductServiceModel> GetAllShoppingCartProducts(string username);

        Task<bool> RemoveProductFromShoppingCart(int id, string username);

        bool AnyProducts(string username);

        Task<bool> RemoveAllProductFromShoppingCart(string username);
    }
}
