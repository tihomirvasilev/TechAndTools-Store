using System;
using System.Collections.Generic;
using System.Text;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class ArticleServiceModel : IMapFrom<Article>, IMapTo<Article>
    {
        
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        public int TimesRead { get; set; }

        public string AuthorId { get; set; }
        public TechAndToolsUser Author { get; set; }

        public ICollection<ImageServiceModel> Images { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
