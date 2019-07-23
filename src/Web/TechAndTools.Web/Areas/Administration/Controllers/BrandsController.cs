using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TechAndTools.Services;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models.Brands;
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

        public async Task<IActionResult> Index()
        {
            List<BrandIndexViewModel> viewModels = await this.brandService.GetAllBrands().To<BrandIndexViewModel>().ToListAsync();

            return this.View(viewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandInputModel brandInputModel)
        {
            if (!ModelState.IsValid)
            {
                return this.Create();
            }

            await this.brandService.CreateBrandAsync(brandInputModel.Name, brandInputModel.LogoUrl, brandInputModel.LogoUrl);

            return this.Redirect("/");
        }

        public IActionResult Details(int id)
        {
            var serviceModel = this.brandService.GetBrandById(id);
            var model = Mapper.Map<BrandDetailsViewModel>(serviceModel);

            return this.View(model);
        }

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
        public IActionResult Delete(int id)
        {
            //TODO: Implement
            return this.Redirect("All");
        }
    }
}