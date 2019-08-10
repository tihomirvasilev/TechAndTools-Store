using System;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Services
{
    public class ProductService : IProductService
    {
        private readonly TechAndToolsDbContext context;

        public ProductService(TechAndToolsDbContext context)
        {
            this.context = context;
        }

        public async Task<ProductServiceModel> CreateAsync(ProductServiceModel productServiceModel)
        {
            Product product = productServiceModel.To<Product>();

            await this.context.Products.AddAsync(product);
            await this.context.SaveChangesAsync();

            return product.To<ProductServiceModel>();
        }

        public async Task<ProductServiceModel> EditAsync(ProductServiceModel productServiceModel)
        {
            Product productFromDb = this.context.Products.Find(productServiceModel.Id);

            productFromDb.Name = productServiceModel.Name;
            productFromDb.ManualUrl = productServiceModel.ManualUrl;
            productFromDb.Description = productServiceModel.Description;
            productFromDb.Price = productServiceModel.Price;
            productFromDb.Warranty = productServiceModel.Warranty;
            productFromDb.BrandId = productServiceModel.BrandId;
            productFromDb.ProductCategoryId = productServiceModel.ProductCategoryId;
            productFromDb.QuantityInStock = productServiceModel.QuantityInStock;

            this.context.Products.Update(productFromDb);
            await this.context.SaveChangesAsync();

            return productServiceModel;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Product productFromDb = this.context.Products.Find(id);

            if (productFromDb == null)
            {
                throw new ArgumentNullException("Entity not found");
            }

            this.context.Products.Remove(productFromDb);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<ProductServiceModel> GetAllProducts()
        {
            return this.context.Products
                .To<ProductServiceModel>();
        }

        public IQueryable<ProductServiceModel> GetProductsByCategoryId(int categoryId)
        {
            return this.context.Products
                .Where(product => product.ProductCategoryId == categoryId)
                .To<ProductServiceModel>();
        }

        public ProductServiceModel GetProductById(int id)
        {
            return this.context.Products
                .Find(id)
                .To<ProductServiceModel>();
        }
    }
}
