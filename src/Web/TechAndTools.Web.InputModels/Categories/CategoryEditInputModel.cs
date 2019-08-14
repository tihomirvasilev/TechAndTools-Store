using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.InputModels.Categories
{
    public class CategoryEditInputModel : IMapFrom<CategoryServiceModel>, IMapTo<CategoryServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int MainCategoryId  { get; set; }
    }
}
