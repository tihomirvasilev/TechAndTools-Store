using System.Threading.Tasks;
using TechAndTools.Services.Models.Brands;

namespace TechAndTools.Services.Contracts
{
    public interface IBrandService
    {
        Task<bool> CreateAsync(BrandServiceModel model);
    }
}
