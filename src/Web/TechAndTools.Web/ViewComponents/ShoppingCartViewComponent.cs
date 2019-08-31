using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TechAndTools.Commons.Constants;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.ViewModels.ShoppingCart;

namespace TechAndTools.Web.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly IShoppingCartService shoppingCartService;

        public ShoppingCartViewComponent(IShoppingCartService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }

        public IViewComponentResult Invoke()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                List<ShoppingCartProductServiceModel> shoppingCartProductsServiceModels = this.shoppingCartService
                    .GetAllShoppingCartProducts(this.User.Identity.Name)
                    .ToList();

                var shoppingCartProductsViewModels = shoppingCartProductsServiceModels
                    .Select(x => x.To<ShoppingCartProductViewModel>())
                    .ToList();

                return this.View(shoppingCartProductsViewModels);
            }

            var shoppingCartSession = SessionHelper.GetObjectFromJson<List<ShoppingCartProductViewModel>>(HttpContext.Session, GlobalConstants.SessionShoppingCartKey) ??
                                      new List<ShoppingCartProductViewModel>();
            
            return this.View(shoppingCartSession);
        }
    }
}
