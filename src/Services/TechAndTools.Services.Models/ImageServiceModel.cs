using TechAndTools.Data.Models;
using TechAndTools.Data.Models.Blog;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class ImageServiceModel : IMapFrom<Image>, IMapTo<Image>
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public int? ProductId { get; set; }
        public ProductServiceModel Product { get; set; }

        public int? BlogPostId { get; set; }
        public BlogPostServiceModel BlogPost { get; set; }
    }
}
