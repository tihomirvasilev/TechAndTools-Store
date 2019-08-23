﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.ViewModels.Favorites;

namespace TechAndTools.Web.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IProductService productService;

        public FavoritesController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult AllFavorites()
        {
            var favoriteProductsServiceModels = this.productService
                .AllFavoriteProducts(this.User.Identity.Name)
                .ToList();

                var viewModels = favoriteProductsServiceModels
                    .Select(x => x.To<FavoriteProductViewModel>())
                    .ToList();

            return View(viewModels);
        }

        public async Task<IActionResult> AddToFavorites(int id)
        {
            await this.productService.AddToFavoritesAsync(id, this.User.Identity.Name);
            
            return RedirectToAction(nameof(AllFavorites));
        }

        public async Task<IActionResult> RemoveFromFavorites(int id)
        {
            await this.productService.RemoveFromFavorites(id, this.User.Identity.Name);

            return RedirectToAction(nameof(AllFavorites));
        }
    }
}