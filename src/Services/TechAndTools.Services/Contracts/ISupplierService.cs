using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Data.Models.Enums;
using TechAndTools.Services.Models;

namespace TechAndTools.Services.Contracts
{
    public interface ISupplierService
    {
        Task<SupplierServiceModel> CreateAsync(SupplierServiceModel supplierServiceModel);

        Task<bool> EditAsync(SupplierServiceModel supplierServiceModel);

        Task<bool> DeleteAsync(int id);

        SupplierServiceModel GetSupplierById(int id);

        IQueryable<SupplierServiceModel> GetAllSuppliers();

        decimal GetDeliveryPrice(int supplierId, ShippingTo shippingTo);
    }
}
