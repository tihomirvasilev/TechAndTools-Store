using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.ViewModels.Brands;

namespace TechAndTools.Web.ViewComponents
{
    public class BrandsFilterViewComponent : ViewComponent
    {
        private readonly IBrandService brandService;

        public BrandsFilterViewComponent(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        public IViewComponentResult Invoke()
        {
            var brandsViewModels = this.brandService.GetAllBrands().To<BrandListViewModel>().ToList();

            return this.View(brandsViewModels);
        }
    }
}
