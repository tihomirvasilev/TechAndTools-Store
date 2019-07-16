namespace TechAndTools.Data.Models
{
    using System.Collections.Generic;

    public class Description
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public virtual ICollection<DescriptionAttribute> DescriptionAttributes { get; set; }
    }
}