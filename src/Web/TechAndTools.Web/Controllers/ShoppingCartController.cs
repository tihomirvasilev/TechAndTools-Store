using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TechAndTools.Commons.Constants;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.ViewModels.ShoppingCart;

namespace TechAndTools.Web.Controllers
{
    [AllowAnonymous]
    public class ShoppingCartController : BaseController
    {
        private readonly IShoppingCartService shoppingCartService;
        private readonly IProductService productService;


        public ShoppingCartController(IShoppingCartService shoppingCartService,
                                      IProductService productService)
        {
            this.shoppingCartService = shoppingCartService;
            this.productService = productService;
        }

        public IActionResult MyCart()
        {

            if (this.User.Identity.IsAuthenticated)
            {
                List<ShoppingCartProductServiceModel> shoppingCartProductsServiceModels = this.shoppingCartService
                    .GetAllShoppingCartProducts(this.User.Identity.Name)
                    .ToList();

                List<ShoppingCartProductViewModel> shoppingCartProductsViewModels = shoppingCartProductsServiceModels
                    .Select(x => x.To<ShoppingCartProductViewModel>())
                    .ToList();

                return this.View(shoppingCartProductsViewModels);
            }

            var shoppingCartSession = SessionHelper
                                          .GetObjectFromJson<List<ShoppingCartProductViewModel>>(HttpContext.Session, TechAndTools.Commons.Constants.GlobalConstants.SessionShoppingCartKey) ??
                                      new List<ShoppingCartProductViewModel>();

            return this.View(shoppingCartSession);
        }

        public IActionResult Add(int id, int quantity)
        {
            if (quantity <= 0)
            {
                return this.RedirectToAction(nameof(MyCart), "ShoppingCart");
            }

            if (this.User.Identity.IsAuthenticated)
            {
                this.shoppingCartService.AddToShoppingCartAsync(id, this.User.Identity.Name, quantity).GetAwaiter();
            }
            else
            {
                List<ShoppingCartProductViewModel> shoppingCartSession =
                    SessionHelper.GetObjectFromJson<List<ShoppingCartProductViewModel>>(HttpContext.Session, TechAndTools.Commons.Constants.GlobalConstants.SessionShoppingCartKey) ??
                                                                          new List<ShoppingCartProductViewModel>();

                if (shoppingCartSession.All(x => x.Id != id))
                {
                    var shoppingCartProduct = this.productService
                        .GetProductById(id)
                        .To<ShoppingCartProductViewModel>();

                    shoppingCartProduct.Quantity = TechAndTools.Commons.Constants.GlobalConstants.DefaultProductQuantity;

                    shoppingCartProduct.TotalPrice = shoppingCartProduct.Quantity * shoppingCartProduct.Price;

                    shoppingCartSession.Add(shoppingCartProduct);

                    SessionHelper.SetObjectAsJson(HttpContext.Session, TechAndTools.Commons.Constants.GlobalConstants.SessionShoppingCartKey, shoppingCartSession);
                }
            }

            ;
            return this.RedirectToAction(nameof(MyCart));
        }

        public IActionResult Delete(int id)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this.shoppingCartService.RemoveProductFromShoppingCart(id, this.User.Identity.Name);

                return this.RedirectToAction(nameof(MyCart), "ShoppingCart");
            }

            List<ShoppingCartProductViewModel> shoppingCartSession =
                SessionHelper.GetObjectFromJson<List<ShoppingCartProductViewModel>>(HttpContext.Session, TechAndTools.Commons.Constants.GlobalConstants.SessionShoppingCartKey);

            if (shoppingCartSession == null)
            {
                return this.RedirectToAction(nameof(MyCart), "ShoppingCart");
            }

            if (shoppingCartSession.Any(x => x.Id == id))
            {
                var product = shoppingCartSession.First(x => x.Id == id);
                shoppingCartSession.Remove(product);

                SessionHelper.SetObjectAsJson(HttpContext.Session, GlobalConstants.SessionShoppingCartKey, shoppingCartSession);
            }

            return this.RedirectToAction(nameof(MyCart), "ShoppingCart");
        }
    }
}