using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.ViewModels.Images
{
    public class ImageViewModel : IMapFrom<ImageServiceModel>
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }
    }
}
