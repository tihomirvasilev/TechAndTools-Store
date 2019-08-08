using System;
using System.Collections.Generic;
using System.Text;
using TechAndTools.Data.Models;
using TechAndTools.Data.Models.Blog;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class BlogPostServiceModel : IMapFrom<BlogPost>, IMapTo<BlogPost>
    {
        
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AdministratorId { get; set; }
        public virtual TechAndToolsUser Administrator { get; set; }

        public virtual ICollection<BlogCommentServiceModel> BlogComments { get; set; }

        public virtual ICollection<ImageServiceModel> Images { get; set; }

        public bool AllowComments { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
