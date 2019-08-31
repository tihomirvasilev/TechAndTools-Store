using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services.Contracts;
using TechAndTools.Web.ViewModels.Products;

namespace TechAndTools.Web.ViewComponents
{
    public class PriceFilterViewComponent : ViewComponent
    {
        private readonly IProductService productService;

        public PriceFilterViewComponent(IProductService productService)
        {
            this.productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var products = this.productService.GetAllProducts().ToList();

            var viewModel = new ProductPriceFilterViewModel
            {
                MinPrice = products.Min(x => x.Price),
                MaxPrice = products.Max(x => x.Price)
            };

            return this.View(viewModel);
        }
    }
}
