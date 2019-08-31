using System.ComponentModel.DataAnnotations;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.InputModels.Contacts
{
    public class CreateContactInputModel : IMapTo<ContactServiceModel>
    {
        [Display(Name = "Име")]
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        [StringLength(25, ErrorMessage = @"""{0}"" може да бъде между {2} и {1} символа.", MinimumLength = 3)]
        public string FullName { get; set; }
        
        
        [Display(Name = "Email")]
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        [StringLength(25, ErrorMessage = @"""{0}"" може да бъде между {2} и {1} символа.", MinimumLength = 3)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Display(Name = "Телефон")]
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        [Phone]
        public string Phone { get; set; }
        
        [Display(Name = "Съдържание")]
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        [StringLength(255, ErrorMessage = @"""{0}"" може да бъде между {2} и {1} символа.", MinimumLength = 3)]
        public string Message { get; set; }
    }
}
