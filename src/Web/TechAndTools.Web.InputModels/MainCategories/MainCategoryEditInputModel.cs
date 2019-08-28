using System.ComponentModel.DataAnnotations;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.InputModels.MainCategories
{
    public class MainCategoryEditInputModel : IMapFrom<MainCategoryServiceModel>, IMapTo<MainCategoryServiceModel>
    {
        public int Id { get; set; }

        
        [Display(Name = "Име")]
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        [StringLength(25, ErrorMessage = @"""{0}"" може да бъде между {2} и {1} символа.", MinimumLength = 3)]
        public string Name { get; set; }
    }
}
