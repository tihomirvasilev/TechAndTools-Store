using System.ComponentModel.DataAnnotations;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.InputModels.Addresses
{
    public class AddressCreateInputModel : IMapTo<AddressServiceModel>
    {
        [Display(Name = "Град")]
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        public string City { get; set; }

        
        [Display(Name = "Адрес")]
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        public string CityAddress { get; set; }

        
        [Display(Name = "Пощенски код")]
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        public int PostCode { get; set; }
    }
}
