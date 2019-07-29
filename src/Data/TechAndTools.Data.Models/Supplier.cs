using System.Collections.Generic;

namespace TechAndTools.Data.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal PriceToOffice { get; set; }

        public decimal PriceToAddress { get; set; }

        public int EstimatedDeliveryTimeMin { get; set; }

        public int EstimatedDeliveryTimeMax { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
