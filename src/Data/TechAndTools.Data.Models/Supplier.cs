namespace TechAndTools.Data.Models
{
    using System;
    using System.Collections.Generic;
    using TechAndTools.Data.Models.Contracts;

    public class Supplier : IDeletableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal PriceToOffice { get; set; }

        public decimal PriceToAddress { get; set; }

        public int EstimatedDeliveryTimeMin { get; set; }

        public int EstimatedDeliveryTimeMax { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
