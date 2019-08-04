using System;
using System.Threading.Tasks;
using TechAndTools.Services.Models;

namespace TechAndTools.Services
{
    public class ProductService : IProductService
    {
        public Task<ProductServiceModel> CreateAsync(ProductServiceModel productServiceModel)
        {
            throw new NotImplementedException();
        }
    }
}
