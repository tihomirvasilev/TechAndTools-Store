using System.Collections.Generic;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class SupplierServiceModel : IMapFrom<Supplier>, IMapTo<Supplier>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal PriceToOffice { get; set; }

        public decimal PriceToAddress { get; set; }

        public int MinimumDeliveryTimeDays { get; set; }

        public int MaximumDeliveryTimeDays { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
