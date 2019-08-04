using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class ImageServiceModel : IMapFrom<Image>, IMapTo<Image>
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }
    }
}
