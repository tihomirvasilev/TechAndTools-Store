using System.ComponentModel.DataAnnotations;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.InputModels.Categories
{
    public class CategoryCreateInputModel : IMapTo<CategoryServiceModel>, IMapFrom<CategoryServiceModel>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int MainCategoryId { get; set; }
    }
}
