using System.ComponentModel.DataAnnotations;

namespace TechAndTools.Web.InputModels.Administration.Brands
{
    public class BrandInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LogoUrl { get; set; }

        [Required]
        public string OfficialSite { get; set; }
    }
}
