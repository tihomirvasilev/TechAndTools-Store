using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.InputModels.Commons;

namespace TechAndTools.Web.InputModels.Articles
{
    public class CreateArticleInputModel : IMapTo<ArticleServiceModel>
    {
        private const int TitleMaxLength = 255;
        private const int TitleMinLength = 3;

        [Required(ErrorMessage = InputModelsConstants.RequiredMessage)]
        [DataType(DataType.Text)]
        [Display(Name = "Заглавие")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = InputModelsConstants.RequiredMessage)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Съдаржание")]
        public string Content { get; set; }

        [Required(ErrorMessage = InputModelsConstants.RequiredMessage)]
        [Display(Name = "Снимка")]
        public IFormFile ImageFormFile { get; set; }
    }
}
