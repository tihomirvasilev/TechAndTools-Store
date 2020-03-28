using System.ComponentModel.DataAnnotations;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.InputModels.Commons;

namespace TechAndTools.Web.InputModels.Articles
{
    using Microsoft.AspNetCore.Http;

    public class CreateArticleInputModel : IMapTo<ArticleServiceModel>
    {
        private const int TitleMaxLength = 255;
        private const int TitleMinLength = 3;

        private const string DisplayName = "Заглавие";
        private const string DisplayContent = "Съдържание";
        private const string DisplayImageFormFile = "Снимка";
        
        [Display(Name = DisplayName)]
        [Required(ErrorMessage = InputModelsConstants.RequiredMessage)]
        [DataType(DataType.Text)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }
        
        [Display(Name = DisplayContent)]
        [Required(ErrorMessage = InputModelsConstants.RequiredMessage)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        
        [Display(Name = DisplayImageFormFile)]
        [Required(ErrorMessage = InputModelsConstants.RequiredMessage)]
        public IFormFile ImageFormFile { get; set; }
    }
}
