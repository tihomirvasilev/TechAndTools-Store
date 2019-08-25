using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.InputModels.Articles
{
    public class EditArticleInputModel : IMapFrom<ArticleServiceModel>
    {
        private const int TitleMaxLength = 255;
        private const int TitleMinLength = 3;

        [Required]
        [DataType(DataType.Text)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Съдържание")]
        public string Content { get; set; }

        [Display(Name = "Снимка")]
        public IFormFile ImageFormFile { get; set; }
    }
}
