using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly TechAndToolsDbContext context;

        public SupplierService(TechAndToolsDbContext context)
        {
            this.context = context;
        }

        public async Task<SupplierServiceModel> CreateAsync(SupplierServiceModel supplierServiceModel)
        {
            Supplier supplier = supplierServiceModel.To<Supplier>();

            await this.context.Suppliers.AddAsync(supplier);
            await this.context.SaveChangesAsync();

            return supplierServiceModel;
        }

        public async Task<bool> EditAsync(SupplierServiceModel supplierServiceModel)
        {
            Supplier supplier = supplierServiceModel.To<Supplier>();

            this.context.Suppliers.Update(supplier);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var supplier = this.context.Suppliers.Find(id);

            this.context.Suppliers.Remove(supplier);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public SupplierServiceModel GetSupplierById(int id)
        {
            return this.context.Suppliers.Find(id).To<SupplierServiceModel>();
        }

        public IQueryable<SupplierServiceModel> GetAllSuppliers()
        {
            return this.context.Suppliers.To<SupplierServiceModel>();
        }
    }
}