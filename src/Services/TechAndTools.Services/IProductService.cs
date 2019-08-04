using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechAndTools.Services.Models;

namespace TechAndTools.Services
{
    public interface IProductService
    {
        Task<ProductServiceModel> CreateAsync(ProductServiceModel productServiceModel);
    }
}
