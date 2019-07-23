using System.Collections.Generic;
using System.Data;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Data.Models
{
    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public string OfficialSite { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
