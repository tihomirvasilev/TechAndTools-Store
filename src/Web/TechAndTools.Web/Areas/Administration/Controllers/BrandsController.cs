using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            var brands = this.brandService.GetAllBrands();

            var viewModels = brands.Select(x => new IndexBrandViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

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
                return Redirect("Index");
            }

            var serviceModel = AutoMapper.Mapper.Map<BrandServiceModel>(brandInputModel);

            await this.brandService.CreateAsync(serviceModel);

            return this.Redirect("/");
        }

        public async Task<IActionResult> Details(int id)
        {
            var serviceModel = await this.brandService.GetBrandById(id);
            var model = Mapper.Map<DetailsBrandViewModel>(serviceModel);
            ;
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