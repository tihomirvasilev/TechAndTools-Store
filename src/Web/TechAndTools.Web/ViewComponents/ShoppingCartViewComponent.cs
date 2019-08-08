using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TechAndTools.Services;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.Commons;
using TechAndTools.Web.ViewModels.ShoppingCart;

namespace TechAndTools.Web.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly IShoppingCartsService shoppingCartService;

        public ShoppingCartViewComponent(IShoppingCartsService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }

        public IViewComponentResult Invoke()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var shoppingCartProductsServiceModels = this.shoppingCartService.GetAllShoppingCartProducts(this.User.Identity.Name).ToList();
                var shoppingCartProductsViewModels = new List<ShoppingCartProductsViewModel>(); 
                foreach (var serviceModel in shoppingCartProductsServiceModels)
                {
                    shoppingCartProductsViewModels.Add(serviceModel.To<ShoppingCartProductsViewModel>());
                }

                return this.View(shoppingCartProductsViewModels);
            }

            var shoppingCartSession = SessionHelper.GetObjectFromJson<List<ShoppingCartProductsViewModel>>(HttpContext.Session, GlobalConstants.SessionShoppingCartKey) ??
                                      new List<ShoppingCartProductsViewModel>();
            ;
            return this.View(shoppingCartSession);
        }
    }
}
