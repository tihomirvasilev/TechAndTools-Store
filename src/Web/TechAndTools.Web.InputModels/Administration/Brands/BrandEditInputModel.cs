using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.InputModels.Administration.Brands
{
    public class BrandEditInputModel : IMapFrom<BrandServiceModel>, IMapTo<BrandServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public string OfficialSite { get; set; }
    }
}
