using System.Threading.Tasks;

namespace TechAndTools.Services.Contracts
{
    public interface IImageService
    {
        Task<bool> CreateWithProductAsync(string imageUrl, int productId);

        Task<bool> CreateWithArticleAsync(string imageUrl, int articleId);
    }
}
