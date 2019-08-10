using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.InputModels.Administration.Suppliers;
using TechAndTools.Web.ViewModels.Suppliers;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    public class SuppliersController : AdministrationController
    {
        private readonly ISupplierService supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        public async Task<IActionResult> All()
        {
            var suppliersViewModels = await this.supplierService
                .GetAllSuppliers()
                .To<SupplierAllViewModel>()
                .ToListAsync();

            return this.View(suppliersViewModels);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupplierCreateInputModel createInputModel)
        {
            await this.supplierService.CreateAsync(createInputModel.To<SupplierServiceModel>());

            return this.RedirectToAction("All", "Suppliers");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var supplierEditInputModel = this.supplierService
                .GetSupplierById(id)
                .To<SupplierEditInputModel>();

            return this.View(supplierEditInputModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(SupplierEditInputModel supplierEditInputModel)
        {
            await this.supplierService.EditAsync(supplierEditInputModel.To<SupplierServiceModel>());

            return this.RedirectToAction("All", "Suppliers");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var supplierDeleteViewModel = this.supplierService
                .GetSupplierById(id)
                .To<SupplierDeleteViewModel>();

            return this.View(supplierDeleteViewModel);
        }

        [HttpPost]
        [Route("/Administration/Suppliers/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await this.supplierService.DeleteAsync(id);

            return this.RedirectToAction("All", "Suppliers");
        }
    }
}