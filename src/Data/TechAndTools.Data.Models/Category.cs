using System.Collections.Generic;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.ViewModels.Administration.Categories;

namespace TechAndTools.Data.Models
{
    public class Category : IMapTo<CategoryViewModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

        public int MainCategoryId  { get; set; }
        public virtual MainCategory MainCategory { get; set; }
    }
}
