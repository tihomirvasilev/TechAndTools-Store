using System.ComponentModel.DataAnnotations;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.InputModels.Commons;

namespace TechAndTools.Web.InputModels.Categories
{
    public class CategoryCreateInputModel : IMapTo<CategoryServiceModel>, IMapFrom<CategoryServiceModel>
    {
        [Display(Name = "Име")]
        [Required(ErrorMessage = InputModelsConstants.RequiredMessage)]
        [StringLength(25, ErrorMessage = @"""{0}"" може да бъде между {2} и {1} символа.", MinimumLength = 3)]
        public string Name { get; set; }
        
        [Display(Name = "Главна категория")]
        [Required(ErrorMessage = InputModelsConstants.RequiredMessage)]
        public int MainCategoryId { get; set; }
    }
}
