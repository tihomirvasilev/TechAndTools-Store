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

        public IActionResult Create()
        {
            return this.Redirect("/");
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupplierInputModel inputModel)
        {
            await this.supplierService.CreateSupplierAsync(inputModel.Name,inputModel.PriceToOffice, inputModel.PriceToAddress, inputModel.MinimumDeliveryTimeDays, inputModel.MaximumDeliveryTimeDays);

            return this.Redirect("All");
        }
    }
}