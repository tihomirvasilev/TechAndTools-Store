using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services.Models.Brands;

namespace TechAndTools.Services
{
    public interface IBrandService
    {
        Task<bool> CreateAsync(BrandServiceModel model);
        IQueryable<BrandServiceModel> GetAllBrands();
        Task<BrandServiceModel> GetBrandById(int id);
    }
}
