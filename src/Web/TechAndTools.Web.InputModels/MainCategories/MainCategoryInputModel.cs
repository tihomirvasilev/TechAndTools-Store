using System.ComponentModel.DataAnnotations;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.InputModels.Commons;

namespace TechAndTools.Web.InputModels.MainCategories
{
    public class MainCategoryInputModel : IMapTo<MainCategoryServiceModel>
    {
        private const int NameMaxLength = 255;
        private const int NameMinLength = 3;

        private const string DisplayName = "Име";

        [Display(Name = DisplayName)]
        [Required(ErrorMessage = InputModelsConstants.RequiredMessage)]
        [StringLength(NameMaxLength, ErrorMessage = InputModelsConstants.StringLengthMessage, MinimumLength = NameMinLength)]
        public string Name { get; set; }
    }
}
