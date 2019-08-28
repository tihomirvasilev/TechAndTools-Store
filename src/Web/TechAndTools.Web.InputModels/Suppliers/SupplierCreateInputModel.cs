using System.ComponentModel.DataAnnotations;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.InputModels.Suppliers
{
    public class SupplierCreateInputModel : IMapTo<SupplierServiceModel>
    {
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        [Display(Name = "Име")]
        [StringLength(20, ErrorMessage = @"""{0}"" може да бъде между {2} и {1} символа.", MinimumLength = 3)]
        public string Name { get; set; }

        
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        [Display(Name = "Цена до офис")]
        [Range(typeof(decimal), "0", "10000", ErrorMessage = @"""{0}"" трябва да е число между {1} и {2}.")]
        public decimal PriceToOffice { get; set; }
        
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        [Display(Name = "Цена до адрес")]
        [Range(typeof(decimal), "0", "10000", ErrorMessage = "{0} може да бъде число между {1} и {2}.")]
        public decimal PriceToAddress { get; set; }

        
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        [Display(Name = "Време за доставка (Дни)")]
        [Range(1, 20, ErrorMessage = @"""{0}"" трябва да е цяло число между {1} и {2}.")]
        public int DeliveryTimeInDays { get; set; }
    }
}
