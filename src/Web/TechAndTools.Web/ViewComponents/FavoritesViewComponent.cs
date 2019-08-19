using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechAndTools.Services.Contracts;

namespace TechAndTools.Web.ViewComponents
{
    public class FavoritesViewComponent : ViewComponent
    {
        
        private readonly IProductService productService;

        public FavoritesViewComponent(IProductService productService)
        {
            this.productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var favoriteProductCount = this.productService.AllFavoriteProducts(this.User.Identity.Name).Count();

            return this.View(favoriteProductCount);
        }
    }
}
