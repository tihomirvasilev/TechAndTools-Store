using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services.Models;

namespace TechAndTools.Services.Contracts
{
    public interface IProductService
    {
        Task<ProductServiceModel> CreateAsync(ProductServiceModel productServiceModel);

        Task<ProductServiceModel> EditAsync(ProductServiceModel productServiceModel);

        Task<bool> DeleteAsync(int id);

        IQueryable<ProductServiceModel> GetAllProducts();

        IQueryable<ProductServiceModel> GetProductsByCategoryId(int categoryId);

        ProductServiceModel GetProductById(int id);

        Task<bool> AddToFavoritesAsync(int id, string username);

        IQueryable<FavoriteProductsServiceModel> AllFavoriteProducts(string username);

        Task<bool> RemoveFromFavorites(int id, string username);
    }
}
