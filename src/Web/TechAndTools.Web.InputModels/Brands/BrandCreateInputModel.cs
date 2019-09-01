using System.ComponentModel.DataAnnotations;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.InputModels.Commons;

namespace TechAndTools.Web.InputModels.Brands
{
    public class BrandCreateInputModel : IMapTo<BrandServiceModel>
    {
        [Display(Name = "Име")]
        [Required(ErrorMessage = InputModelsConstants.RequiredMessage)]
        [StringLength(25, ErrorMessage = @"""{0}"" може да бъде между {2} и {1} символа.", MinimumLength = 3)]
        public string Name { get; set; }
        
        [Display(Name = "Лого")]
        [Required(ErrorMessage = InputModelsConstants.RequiredMessage)]
        public string LogoUrl { get; set; }
        
        [Display(Name = "Официален сайт")]
        [Required(ErrorMessage = InputModelsConstants.RequiredMessage)]
        public string OfficialSite { get; set; }
    }
}
