using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.ViewModels;
using TechAndTools.Web.ViewModels.Products;

namespace TechAndTools.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public HomeController(IProductService productService,
            ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            IList<ProductIndexViewModel> productIndexViewModels = this.productService.GetAllProducts().To<ProductIndexViewModel>().ToList();

            return View(productIndexViewModels);
        }

        [Route("/Home/Index/{categoryId}")]
        public async Task<IActionResult> Index(int categoryId)
        {
            IList<ProductIndexViewModel> productIndexViewModels = this.productService.GetProductsByCategoryId(categoryId).To<ProductIndexViewModel>().ToList();
            ViewData["category"] = this.categoryService.GetCategoryById(categoryId).Name;
            return View(productIndexViewModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
