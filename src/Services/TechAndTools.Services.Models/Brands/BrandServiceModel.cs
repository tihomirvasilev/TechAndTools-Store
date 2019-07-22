using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models.Brands
{
    public class BrandServiceModel : IMapFrom<Brand>, IMapTo<Brand>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public string OfficialSite { get; set; }
    }
}
