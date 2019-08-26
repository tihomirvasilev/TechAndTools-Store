using System.Threading.Tasks;
using TechAndTools.Services.Models;

namespace TechAndTools.Services.Contracts
{
    public interface IImageService
    {
        Task<bool> CreateWithProductAsync(string imageUrl, int productId);

        Task<bool> CreateWithArticleAsync(string imageUrl, int articleId);

        Task<ImageServiceModel> EditWithArticleAsync(string imageUrl, int articleId);
    }
}
