using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.ViewModels.Administration.Brands
{
    public class BrandIndexViewModel : IMapFrom<BrandServiceModel>

    {
    public int Id { get; set; }

    public string Name { get; set; }
    }
}
