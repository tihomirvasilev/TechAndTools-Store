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

        public int DeliveryTimeInDays { get; set; }

        public ICollection<OrderServiceModel> Orders { get; set; }
    }
}
