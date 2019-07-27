using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Data.Models;

namespace TechAndTools.Services
{
    public interface IBrandService
    {
        Task<Brand> CreateBrandAsync(string name, string logoUrl, string officialSite);
        IQueryable<Brand> GetAllBrands();
        Brand GetBrandById(int brandId);
    }
}
