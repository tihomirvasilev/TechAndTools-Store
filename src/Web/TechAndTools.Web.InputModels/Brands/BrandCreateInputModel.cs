using System.ComponentModel.DataAnnotations;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.InputModels.Brands
{
    public class BrandCreateInputModel : IMapTo<BrandServiceModel>
    {
        [Display(Name = "Име")]
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        [StringLength(25, ErrorMessage = @"""{0}"" може да бъде между {2} и {1} символа.", MinimumLength = 3)]
        public string Name { get; set; }
        
        [Display(Name = "Лого")]
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        public string LogoUrl { get; set; }
        
        [Display(Name = "Официален сайт")]
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        public string OfficialSite { get; set; }
    }
}
