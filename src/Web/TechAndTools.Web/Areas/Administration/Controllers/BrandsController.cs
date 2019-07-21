using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Models.Brands;
using TechAndTools.Web.InputModels.Administration.Brands;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    public class BrandsController : AdministrationController
    {
        private readonly IBrandService brandService;

        public BrandsController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandInputModel brandInputModel)
        {
            BrandServiceModel serviceModel = new BrandServiceModel
            {
                LogoUrl = brandInputModel.LogoUrl,
                Name = brandInputModel.Name,
                OfficialSite = brandInputModel.OfficialSite
            };

            await this.brandService.CreateAsync(serviceModel);

            return this.Redirect("/");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            //TODO: Implement
            return this.Redirect("All");
        }

        [HttpGet]
        public IActionResult All()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            //TODO: Implement
            return this.Redirect("All");
        }
    }
}