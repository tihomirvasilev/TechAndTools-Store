using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.ViewModels.Administration.Suppliers
{
    public class SupplierAllViewModel : IMapFrom<SupplierServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal PriceToOffice { get; set; }

        public decimal PriceToAddress { get; set; }

        public int MinimumDeliveryTimeDays { get; set; }

        public int MaximumDeliveryTimeDays { get; set; }
    }
}
