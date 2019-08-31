using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TechAndTools.Commons.Constants;
using TechAndTools.Data.Models;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.InputModels.Orders;
using TechAndTools.Web.ViewModels.Addresses;
using TechAndTools.Web.ViewModels.Orders;
using TechAndTools.Web.ViewModels.PaymentMethods;
using TechAndTools.Web.ViewModels.ShoppingCart;
using TechAndTools.Web.ViewModels.Suppliers;

namespace TechAndTools.Web.Controllers
{
    [Authorize(Roles = GlobalConstants.UserRole +", " + GlobalConstants.AdminRole)]
    public class OrdersController : BaseController
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

            TechAndToolsUser user = this.userService
                .GetUserByUsername(this.User.Identity.Name);

            IEnumerable<AddressViewModel> addressesViewModel = this.addressService
                .GetAllByUserId(this.User.FindFirstValue(ClaimTypes.NameIdentifier))
                .To<AddressViewModel>()
                .ToList();

            IEnumerable<SupplierViewModel> supplierViewModels = this.supplierService
                .GetAllSuppliers()
                .To<SupplierViewModel>()
                .ToList();

            IEnumerable<ShoppingCartProductServiceModel> shoppingCartProductsServiceModels = this.shoppingCartService
                .GetAllShoppingCartProducts(this.User.Identity.Name)
                .ToList();

            IEnumerable<PaymentMethodViewModel> paymentMethodViewModels = this.paymentMethodService
                .GetAllPaymentMethods()
                .To<PaymentMethodViewModel>()
                .ToList();

            IEnumerable<ShoppingCartProductViewModel> shoppingCartProductsViewModels = shoppingCartProductsServiceModels
                .Select(x => x.To<ShoppingCartProductViewModel>())
                .ToList();

            CreateOrderInputModel createOrderViewModel = new CreateOrderInputModel
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
        public async Task<IActionResult> Create(CreateOrderInputModel createOrderInputModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }

            decimal deliveryPrice = this.supplierService.GetDeliveryPrice(createOrderInputModel.SupplierId, createOrderInputModel.ShippingTo);
            var orderServiceModel = createOrderInputModel.To<OrderServiceModel>();

            var order = await this.orderService.CreateAsync(orderServiceModel, this.User.Identity.Name, deliveryPrice);
            
            return this.RedirectToAction(nameof(Complete), new {id = order.Id});
        }

        public IActionResult Complete(int id)
        {
            CompleteOrderViewModel viewModel = new CompleteOrderViewModel {OrderId = id};

            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            DetailsOrderViewModel viewModel = this.orderService.GetOrderById(id).To<DetailsOrderViewModel>();
            
            return this.View(viewModel);
        }

        public IActionResult My()
        {
            string username = this.User.Identity.Name;

            IEnumerable<OrderServiceModel> serviceModels = this.orderService
                .GetAllOrdersByUserId(username)
                .ToList();

            IEnumerable<MyOrdersViewModel> viewModels = serviceModels
                .Select(x => x.To<MyOrdersViewModel>())
                .ToList();

            return this.View(viewModels);
        }
    }
}