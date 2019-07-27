using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechAndTools.Data.Models;

namespace TechAndTools.Services
{
    public interface ISupplierService
    {
        Task<Supplier> CreateSupplierAsync();
        Supplier GetSupplierById();

    }
}
