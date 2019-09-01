using System.ComponentModel.DataAnnotations;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.InputModels.Commons;

namespace TechAndTools.Web.InputModels.Addresses
{
    public class AddressCreateInputModel : IMapTo<AddressServiceModel>
    {
        [Display(Name = "Град")]
        [Required(ErrorMessage = InputModelsConstants.RequiredMessage)]
        public string City { get; set; }

        
        [Display(Name = "Адрес")]
        [Required(ErrorMessage = InputModelsConstants.RequiredMessage)]
        public string CityAddress { get; set; }

        
        [Display(Name = "Пощенски код")]
        [Required(ErrorMessage = InputModelsConstants.RequiredMessage)]
        public int PostCode { get; set; }
    }
}
