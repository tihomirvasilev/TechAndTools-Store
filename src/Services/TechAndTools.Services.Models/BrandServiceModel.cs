using System.Collections.Generic;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class BrandServiceModel : IMapTo<Brand>, IMapFrom<Brand>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public string OfficialSite { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
