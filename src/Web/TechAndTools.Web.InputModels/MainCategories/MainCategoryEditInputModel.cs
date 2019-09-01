using System.ComponentModel.DataAnnotations;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.InputModels.Commons;

namespace TechAndTools.Web.InputModels.MainCategories
{
    public class MainCategoryEditInputModel : IMapFrom<MainCategoryServiceModel>, IMapTo<MainCategoryServiceModel>
    {
        [Display(Name = "Име")]
        [Required(ErrorMessage = InputModelsConstants.RequiredMessage)]
        [StringLength(25, ErrorMessage = @"""{0}"" може да бъде между {2} и {1} символа.", MinimumLength = 3)]
        public string Name { get; set; }
    }
}
