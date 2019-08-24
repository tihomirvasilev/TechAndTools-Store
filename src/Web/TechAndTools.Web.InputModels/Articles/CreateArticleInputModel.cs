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
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public IFormFile ImageFormFile { get; set; }
    }
}
