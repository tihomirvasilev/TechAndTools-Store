namespace TechAndTools.Data.Models.Blog
{
    using System;
    using System.Collections.Generic;
    using TechAndTools.Data.Models.Contracts;
    public class BlogPost : IAuditInfo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AdministratorId { get; set; }
        public virtual TechAndToolsUser Administrator { get; set; }

        public virtual ICollection<BlogComment> BlogComments { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public bool AllowComments { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
