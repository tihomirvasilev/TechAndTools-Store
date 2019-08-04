using System;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Services
{
    public class BrandService : IBrandService
    {
        private readonly TechAndToolsDbContext context;

        public BrandService(TechAndToolsDbContext context)
        {
            this.context = context;
        }

        public async Task<BrandServiceModel> CreateAsync(BrandServiceModel serviceModel)
        {

            Brand brand = serviceModel.To<Brand>();

            await this.context.Brands.AddAsync(brand);

            await this.context.SaveChangesAsync();

            return serviceModel;
        }

        public async Task<BrandServiceModel> EditAsync(BrandServiceModel serviceModel)
        {
            Brand brand = serviceModel.To<Brand>();

            this.context.Brands.Update(brand);

            await this.context.SaveChangesAsync();

            return serviceModel;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Brand brand = this.context.Brands.Find(id);

            if (brand == null)
            {
                throw new ArgumentNullException(nameof(brand));
            }

            this.context.Brands.Remove(brand);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<BrandServiceModel> GetAllBrands()
        {
            return this.context.Brands.To<BrandServiceModel>();
        }

        public BrandServiceModel GetBrandById(int brandId)
        {
            return this.context.Brands.FirstOrDefault(brand => brand.Id == brandId).To<BrandServiceModel>();
        }
    }
}
