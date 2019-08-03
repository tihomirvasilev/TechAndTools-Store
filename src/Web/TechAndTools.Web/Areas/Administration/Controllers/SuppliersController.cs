using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using TechAndTools.Services;
using TechAndTools.Web.InputModels.Administration.Suppliers;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    public class SuppliersController : AdministrationController
    {
        private readonly ISupplierService supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        public IActionResult All()
        {
            return View();
        }

        public Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupplierInputModel inputModel)
        {
            await this.supplierService.CreateSupplierAsync();
            return this.Redirect("All");
        }
    }
}