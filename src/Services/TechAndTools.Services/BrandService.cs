using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Data;
using TechAndTools.Data.Models;

namespace TechAndTools.Services
{
    public class BrandService : IBrandService
    {
        private readonly TechAndToolsDbContext context;

        public BrandService(TechAndToolsDbContext context)
        {
            this.context = context;
        }

        public async Task<Brand> CreateBrandAsync(string name, string logoUrl, string officialSite)
        {
            
            var brand = new Brand
            {
                Name = name,
                LogoUrl = logoUrl,
                OfficialSite = officialSite
            };

            await this.context.Brands.AddAsync(brand);

            await this.context.SaveChangesAsync();

            return brand;
        }

        public async Task<IEnumerable<Brand>> GetAllBrands()
        {
            return await this.context.Brands.ToListAsync();
        }

        public Brand GetBrandById(int brandId)
        {
            return this.context.Brands.FirstOrDefault(brand => brand.Id == brandId);
        }
    }
}
