using System.Collections.Generic;

namespace TechAndTools.Web.InputModels.Administration.Products
{
    public class ProductInputModel
    {
        public string Name { get; set; }

        public int ProductCategoryId { get; set; }

        public int BrandId { get; set; }

        public ICollection<string> ImagesUrls { get; set; }

        public string Description { get; set; }

        public string DocumentationUrl { get; set; }

        public int Warranty { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
