using System;
using TechAndTools.Data.Models;
using TechAndTools.Data.Models.Blog;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class BlogCommentServiceModel : IMapFrom<BlogComment>, IMapTo<BlogComment>
    {
        
        public string UserId { get; set; }
        public virtual TechAndToolsUser User { get; set; }

        public int BlogPostId { get; set; }
        public virtual BlogPostServiceModel BlogPost { get; set; }

        public string Comment { get; set; }

        public double Rating { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
