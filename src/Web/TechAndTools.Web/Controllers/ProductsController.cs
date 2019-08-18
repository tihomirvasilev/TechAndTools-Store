using Microsoft.AspNetCore.Mvc;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.ViewModels.Products;

namespace TechAndTools.Web.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Details(int id)
        {
            var serviceModel = this.productService.GetProductById(id);
            ;
            ProductDetailsViewModel viewModel = this.productService.GetProductById(id).To<ProductDetailsViewModel>();
            ;
            return View(viewModel);
        }
    }
}