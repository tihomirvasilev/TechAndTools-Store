using System.ComponentModel.DataAnnotations;

namespace TechAndTools.Web.InputModels.Administration.Categories
{
    public class MainCategoryInputModel
    {
        [Required]
        [MinLength(3)]
        [RegularExpression("[a-zA-z0-9]+")]
        public string Name { get; set; }
    }
}
