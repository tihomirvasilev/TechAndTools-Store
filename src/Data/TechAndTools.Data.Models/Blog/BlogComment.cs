namespace TechAndTools.Data.Models.Blog
{
    using System;
    using TechAndTools.Data.Models.Contracts;

    public class BlogComment : IAuditInfo
    {
        public string UserId { get; set; }
        public virtual TechAndToolsUser User { get; set; }

        public int BlogPostId { get; set; }
        public virtual BlogPost BlogPost { get; set; }

        public string Comment { get; set; }

        public double Rating { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
