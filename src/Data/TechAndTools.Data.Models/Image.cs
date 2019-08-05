using System.Data;
using TechAndTools.Data.Models.Blog;

namespace TechAndTools.Data.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int? BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
    }
}
