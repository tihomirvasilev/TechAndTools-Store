using System.ComponentModel.DataAnnotations;

namespace TechAndTools.Web.InputModels.Administration.Categories
{
    public class CategoryInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string MainCategory { get; set; }
    }
}
