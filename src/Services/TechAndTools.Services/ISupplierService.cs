using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services.Models;

namespace TechAndTools.Services
{
    public interface ISupplierService
    {
        Task<SupplierServiceModel> CreateAsync(SupplierServiceModel supplierServiceModel);

        Task<bool> EditAsync(SupplierServiceModel supplierServiceModel);

        Task<bool> DeleteAsync(int id);

        SupplierServiceModel GetSupplierById(int id);

        IQueryable<SupplierServiceModel> GetAllSuppliers();
    }
}
