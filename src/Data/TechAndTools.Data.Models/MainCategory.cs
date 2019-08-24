using System.Collections.Generic;

namespace TechAndTools.Data.Models
{
    public class MainCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
