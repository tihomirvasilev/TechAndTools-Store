using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.InputModels.Suppliers
{
    public class SupplierCreateInputModel : IMapTo<SupplierServiceModel>
    {
        public string Name { get; set; }

        public decimal PriceToOffice { get; set; }

        public decimal PriceToAddress { get; set; }

        public int DeliveryTimeInDays { get; set; }
    }
}
