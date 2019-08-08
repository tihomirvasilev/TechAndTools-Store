using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechAndTools.Services;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.Commons;
using TechAndTools.Web.ViewModels.ShoppingCart;

namespace TechAndTools.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartsService shoppingCartService;
        private readonly IProductService productService;


        public ShoppingCartController(IShoppingCartsService shoppingCartService,
                                      IProductService productService)
        {
            this.shoppingCartService = shoppingCartService;
            this.productService = productService;
        }

        public IActionResult Add(int id)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this.shoppingCartService.AddToShoppingCart(id, this.User.Identity.Name, 1);
            }
            else
            {
                List<ShoppingCartProductsViewModel> shoppingCartSession = 
                    SessionHelper.GetObjectFromJson<List<ShoppingCartProductsViewModel>>(HttpContext.Session, GlobalConstants.SessionShoppingCartKey) ??
                                                                          new List<ShoppingCartProductsViewModel>();

                if (shoppingCartSession.All(x => x.Id != id))
                {
                    var shoppingCartProduct = this.productService.GetProductById(id).To<ShoppingCartProductsViewModel>();

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

                return this.RedirectToAction("Index", "Home");
            }

            List<ShoppingCartProductsViewModel> shoppingCartSession =
                SessionHelper.GetObjectFromJson<List<ShoppingCartProductsViewModel>>(HttpContext.Session, GlobalConstants.SessionShoppingCartKey);
            if (shoppingCartSession == null)
            {
                return this.RedirectToAction("Index", "Home");
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