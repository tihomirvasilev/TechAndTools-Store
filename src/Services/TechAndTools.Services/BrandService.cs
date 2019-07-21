using System.Threading.Tasks;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Models.Brands;

namespace TechAndTools.Services
{
    public class BrandService : IBrandService
    {
        private readonly TechAndToolsDbContext context;

        public BrandService(TechAndToolsDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateAsync(BrandServiceModel model)
        {
            var brand = new Brand
            {
                Name = model.Name,
                LogoUrl = model.LogoUrl,
                OfficialSite = model.OfficialSite
            };

            this.context.Brands.Add(brand);

            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }
    }
}
