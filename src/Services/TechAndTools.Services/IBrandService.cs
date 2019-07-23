using System.Collections.Generic;
using System.Threading.Tasks;
using TechAndTools.Data.Models;

namespace TechAndTools.Services
{
    public interface IBrandService
    {
        Task<Brand> CreateBrandAsync(string name, string logoUrl, string officialSite);
        Task<IEnumerable<Brand>> GetAllBrands();
        Brand GetBrandById(int brandId);
    }
}
