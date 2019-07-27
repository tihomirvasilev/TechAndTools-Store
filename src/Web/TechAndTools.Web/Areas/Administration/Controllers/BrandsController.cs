using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechAndTools.Services;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.InputModels.Administration.Brands;
using TechAndTools.Web.ViewModels.Administration.Brands;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    public class BrandsController : AdministrationController
    {
        private readonly IBrandService brandService;
        private readonly IMapper mapper;

        public BrandsController(IBrandService brandService, IMapper mapper)
        {
            this.brandService = brandService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var viewModels = this.brandService.GetAllBrands().To<BrandIndexViewModel>();

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
            var model = Mapper.Map<BrandDetailsViewModel>(this.brandService.GetBrandById(id));

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