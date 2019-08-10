using System.Threading.Tasks;

namespace TechAndTools.Services.Contracts
{
    public interface IImageService
    {
        Task<bool> CreateAsync(string imageUrl, int productId);
    }
}
