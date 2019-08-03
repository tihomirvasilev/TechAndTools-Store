using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Data;
using TechAndTools.Data.Models;

namespace TechAndTools.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly TechAndToolsDbContext context;

        public SupplierService(TechAndToolsDbContext context)
        {
            this.context = context;
        }

        public async Task<Supplier> CreateSupplierAsync(string name, decimal priceToOffice, decimal priceToAddress, int minimumDeliveryTimeDays,
            int maximumDeliveryTimeDays)
        {
            var supplier = new Supplier
            {
                Name = name,
                PriceToOffice = priceToOffice,
                PriceToAddress = priceToAddress,
                MinimumDeliveryTimeDays = minimumDeliveryTimeDays,
                MaximumDeliveryTimeDays = maximumDeliveryTimeDays
            };

            await this.context.Suppliers.AddAsync(supplier);
            await this.context.SaveChangesAsync();

            return supplier;
        }

        public Supplier GetSupplierById(int id)
        {
            return this.context.Suppliers.FirstOrDefault(supp => supp.Id == id);
        }

        public IQueryable<Order> GetAllOrdersBySupplierId(int id)
        {
            return this.context.Suppliers.Find(id).Orders.AsQueryable();
        }
    }
}