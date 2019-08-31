using System.Collections.Generic;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.ViewModels.Products
{
    public class ProductAllViewModel : IMapFrom<ProductServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int QuantityInStock { get; set; }

        public int SalesCount { get; set; }

        public string ProductCategoryName { get; set; }

        public ICollection<ImageServiceModel> Images { get; set; }
    }
}
