using System.ComponentModel.DataAnnotations;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.InputModels.MainCategories
{
    public class MainCategoryInputModel : IMapTo<MainCategoryServiceModel>
    {
        [Required]
        [MinLength(3)]
        [RegularExpression("[a-zA-z0-9]+")]
        public string Name { get; set; }
    }
}
