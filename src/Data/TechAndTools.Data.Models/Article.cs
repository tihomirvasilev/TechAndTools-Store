using System;
using System.Collections.Generic;

namespace TechAndTools.Data.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int TimesRead { get; set; }

        public string AuthorId { get; set; }
        public virtual TechAndToolsUser Author { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
