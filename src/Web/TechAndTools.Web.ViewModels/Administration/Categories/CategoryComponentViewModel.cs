using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.ViewModels.Administration.Categories
{
    public class CategoryComponentViewModel : IMapFrom<CategoryServiceModel>
    {
        public string Name { get; set; }

        //TODO: Add products view models ???
    }
}
