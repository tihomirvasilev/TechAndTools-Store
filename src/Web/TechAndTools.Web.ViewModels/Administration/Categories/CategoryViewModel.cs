using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.ViewModels.Administration.Categories
{
    public class CategoryViewModel : IMapFrom<CategoryServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
