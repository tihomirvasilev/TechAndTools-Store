using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Data.Models;

namespace TechAndTools.Services
{
    public interface ISupplierService
    {
        Task<Supplier> CreateSupplierAsync(string name,decimal priceToOffice, decimal priceToAddress, int minimumDeliveryTimeDays, int maximumDeliveryTimeDays);

        Supplier GetSupplierById(int id);

        IQueryable<Order> GetAllOrdersBySupplierId(int id);
    }
}
