using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.Commons;
using TechAndTools.Web.ViewModels.ShoppingCart;

namespace TechAndTools.Web.Controllers
{
    public class ShoppingCartController : Controller
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
                                          .GetObjectFromJson<List<ShoppingCartProductViewModel>>(HttpContext.Session, GlobalConstants.SessionShoppingCartKey) ??
                                      new List<ShoppingCartProductViewModel>();

            return this.View(shoppingCartSession);
        }

        public IActionResult Add(int id, int quantity)
        {
            //TODO fix bug with 0 quantity from favorites

            if (this.User.Identity.IsAuthenticated)
            {
                this.shoppingCartService.AddToShoppingCart(id, this.User.Identity.Name, quantity);
            }
            else
            {
                List<ShoppingCartProductViewModel> shoppingCartSession =
                    SessionHelper.GetObjectFromJson<List<ShoppingCartProductViewModel>>(HttpContext.Session, GlobalConstants.SessionShoppingCartKey) ??
                                                                          new List<ShoppingCartProductViewModel>();

                if (shoppingCartSession.All(x => x.Id != id))
                {
                    var shoppingCartProduct = this.productService
                        .GetProductById(id)
                        .To<ShoppingCartProductViewModel>();

                    shoppingCartProduct.Quantity = GlobalConstants.DefaultProductQuantity;

                    shoppingCartProduct.TotalPrice = shoppingCartProduct.Quantity * shoppingCartProduct.Price;

                    shoppingCartSession.Add(shoppingCartProduct);

                    SessionHelper.SetObjectAsJson(HttpContext.Session, GlobalConstants.SessionShoppingCartKey, shoppingCartSession);
                }
            }

            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this.shoppingCartService.DeleteProductFromShoppingCart(id, this.User.Identity.Name);

                return this.RedirectToAction("MyCart", "ShoppingCart");
            }

            List<ShoppingCartProductViewModel> shoppingCartSession =
                SessionHelper.GetObjectFromJson<List<ShoppingCartProductViewModel>>(HttpContext.Session, GlobalConstants.SessionShoppingCartKey);
            if (shoppingCartSession == null)
            {
                return this.RedirectToAction("MyCart", "ShoppingCart");
            }

            if (shoppingCartSession.Any(x => x.Id == id))
            {
                var product = shoppingCartSession.First(x => x.Id == id);
                shoppingCartSession.Remove(product);

                SessionHelper.SetObjectAsJson(HttpContext.Session, GlobalConstants.SessionShoppingCartKey, shoppingCartSession);
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}