using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechAndTools.Data.Models;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.InputModels.Orders;
using TechAndTools.Web.ViewModels.Addresses;
using TechAndTools.Web.ViewModels.PaymentMethods;
using TechAndTools.Web.ViewModels.ShoppingCart;
using TechAndTools.Web.ViewModels.Suppliers;

namespace TechAndTools.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IShoppingCartService shoppingCartService;
        private readonly IUserService userService;
        private readonly ISupplierService supplierService;
        private readonly IAddressService addressService;
        private readonly IPaymentMethodService paymentMethodService;
        private readonly IOrderService orderService;

        public OrdersController(IShoppingCartService shoppingCartService,
            IUserService userService,
            ISupplierService supplierService,
            IAddressService addressService,
            IPaymentMethodService paymentMethodService,
            IOrderService orderService)
        {
            this.shoppingCartService = shoppingCartService;
            this.userService = userService;
            this.supplierService = supplierService;
            this.addressService = addressService;
            this.paymentMethodService = paymentMethodService;
            this.orderService = orderService;
        }

        public IActionResult Create()
        {
            if (!this.shoppingCartService.AnyProducts(this.User.Identity.Name))
            {
                return RedirectToAction("Index", "Home");
            }

            List<AddressViewModel> addressesViewModel = this.addressService
                .GetAllByUserId(this.User.FindFirstValue(ClaimTypes.NameIdentifier))
                .To<AddressViewModel>()
                .ToList();

            TechAndToolsUser user = this.userService
                .GetUserByUsername(this.User.Identity.Name);

            List<SupplierViewModel> supplierViewModels = this.supplierService
                .GetAllSuppliers()
                .To<SupplierViewModel>()
                .ToList();

            List<ShoppingCartProductServiceModel> shoppingCartProductsServiceModels = this.shoppingCartService
                .GetAllShoppingCartProducts(this.User.Identity.Name)
                .ToList();

            List<PaymentMethodViewModel> paymentMethodViewModels = this.paymentMethodService
                .GetAllPaymentMethods()
                .To<PaymentMethodViewModel>().ToList();

            List<ShoppingCartProductViewModel> shoppingCartProductsViewModels = shoppingCartProductsServiceModels
                .Select(x => x.To<ShoppingCartProductViewModel>())
                .ToList();

            var createOrderViewModel = new OrderCreateInputModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                AddressesViewModels = addressesViewModel.ToList(),
                SuppliersViewModel = supplierViewModels,
                ShoppingCartProductViewModels = shoppingCartProductsViewModels,
                PaymentMethodViewModels = paymentMethodViewModels
            };

            return this.View(createOrderViewModel);
        }

        [HttpPost]
        public IActionResult Create(OrderCreateInputModel orderCreateInputModel)
        {
            if (!this.shoppingCartService.AnyProducts(this.User.Identity.Name))
            {
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }

            decimal deliveryPrice = this.supplierService.GetDeliveryPrice(orderCreateInputModel.SupplierId, orderCreateInputModel.ShippingTo);

            var order = this.orderService.Create(orderCreateInputModel.To<OrderServiceModel>(), this.User.Identity.Name, deliveryPrice);

            return this.RedirectToAction(nameof(Confirm));
        }

        public async Task<IActionResult> Confirm()
        {
            return this.View();
        }
    }
}