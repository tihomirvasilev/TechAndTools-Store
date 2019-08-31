using System.Threading.Tasks;
using TechAndTools.Services.Models;

namespace TechAndTools.Services.Contracts
{
    public interface IImageService
    {
        Task<ImageServiceModel> CreateWithProductAsync(string imageUrl, int productId);

        Task<ImageServiceModel> CreateWithArticleAsync(string imageUrl, int articleId);

        Task<ImageServiceModel> EditWithArticleAsync(string imageUrl, int articleId);
    }
}
