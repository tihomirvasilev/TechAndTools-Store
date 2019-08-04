using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.InputModels.Administration.Brands;
using TechAndTools.Web.ViewModels.Administration.Brands;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    public class BrandsController : AdministrationController
    {
        private readonly IBrandService brandService;

        public BrandsController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(BrandInputModel brandInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Add();
            }

            await this.brandService.CreateAsync(brandInputModel.To<BrandServiceModel>());

            return this.RedirectToAction("All", "Brands");
        }

        public IActionResult Edit(int id)
        {
            BrandEditInputModel brandEditInputModel = this.brandService.GetBrandById(id).To<BrandEditInputModel>();

            return this.View(brandEditInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BrandEditInputModel brandEditInputModel)
        {
            await this.brandService.EditAsync(brandEditInputModel.To<BrandServiceModel>());

            return this.RedirectToAction("All", "Brands");
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            BrandDeleteVIewModel brandDeleteVIewModel = this.brandService.GetBrandById(id).To<BrandDeleteVIewModel>();

            return this.View(brandDeleteVIewModel);
        }

        [HttpPost]
        [Route("/Administration/Brands/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await this.brandService.DeleteAsync(id);

            return this.RedirectToAction("All", "Brands");
        }

        public IActionResult All()
        {
            var viewModels = this.brandService.GetAllBrands().To<BrandIndexViewModel>().ToList();

            return this.View(viewModels);
        }

    }
}