using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.InputModels.Articles
{
    public class CreateArticleInputModel : IMapTo<ArticleServiceModel>
    {
        private const int TitleMaxLength = 255;
        private const int TitleMinLength = 3;

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Заглавие")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Съдаржание")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Снимка")]
        public IFormFile ImageFormFile { get; set; }
    }
}
