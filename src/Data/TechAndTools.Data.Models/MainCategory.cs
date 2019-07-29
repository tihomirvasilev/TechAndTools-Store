using System.Collections.Generic;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.ViewModels.Administration.MainCategories;

namespace TechAndTools.Data.Models
{
    public class MainCategory : IMapTo<MainCategoryViewModel>, IMapTo<AddCategoryMainCategoryViewModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    }
}
