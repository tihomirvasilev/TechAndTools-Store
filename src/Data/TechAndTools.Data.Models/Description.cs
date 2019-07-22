using System.Collections.Generic;

namespace TechAndTools.Data.Models
{
    public class Description
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public virtual ICollection<DescriptionProperty> DescriptionAttributes { get; set; }
    }
}