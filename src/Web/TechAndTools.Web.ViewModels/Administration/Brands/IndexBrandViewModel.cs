using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models.Brands;

namespace TechAndTools.Web.ViewModels.Administration.Brands
{
    public class IndexBrandViewModel : IMapFrom<BrandServiceModel>

    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
