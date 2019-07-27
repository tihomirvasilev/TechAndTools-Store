using System.Collections.Generic;
using System.Data;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.ViewModels.Administration.Brands;

namespace TechAndTools.Data.Models
{
    public class Brand : IMapTo<BrandIndexViewModel>, IMapTo<BrandDetailsViewModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public string OfficialSite { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
