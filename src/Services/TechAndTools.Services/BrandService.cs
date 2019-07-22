using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Models.Brands;
using TechAndTools.Services.Mapping;

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
            var brand = AutoMapper.Mapper.Map<Brand>(model);

            this.context.Brands.Add(brand);

            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<BrandServiceModel> GetAllBrands()
        {
            return this.context.Brands.To<BrandServiceModel>();
        }

        public async Task<BrandServiceModel> GetBrandById(int id)
        {
            var brand = await this.context.Brands.FirstOrDefaultAsync(x => x.Id == id);

            var model = Mapper.Map<BrandServiceModel>(brand);

            return model;
        }
    }
}
