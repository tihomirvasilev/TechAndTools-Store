using System.Collections.Generic;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class MainCategoryServiceModel : IMapFrom<MainCategory>, IMapTo<MainCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<CategoryServiceModel> Categories { get; set; }
    }
}
