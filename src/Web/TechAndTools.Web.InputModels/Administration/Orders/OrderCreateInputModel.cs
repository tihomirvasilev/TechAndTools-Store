using System.Collections.Generic;
using TechAndTools.Data.Models.Enums;
using TechAndTools.Web.InputModels.Addresses;
using TechAndTools.Web.ViewModels.Addresses;
using TechAndTools.Web.ViewModels.PaymentMethods;
using TechAndTools.Web.ViewModels.ShoppingCart;
using TechAndTools.Web.ViewModels.Suppliers;

namespace TechAndTools.Web.InputModels.Administration.Orders
{
    public class OrderCreateInputModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public IEnumerable<AddressViewModel> AddressesViewModels { get; set; }

        public AddressCreateInputModel AddressCreateInputModel { get; set; }

        public IEnumerable<SupplierViewModel> SuppliersViewModel { get; set; }

        public ShippingTo To { get; set; }

        public int SupplierId { get; set; }

        public int? DeliveryAddressId { get; set; }


        public ShippingTo ShippingTo { get; set; }

        public IEnumerable<PaymentMethodViewModel> PaymentMethodViewModels { get; set; }

        public IEnumerable<ShoppingCartProductViewModel> ShoppingCartProductViewModels { get; set; }
    }
}
