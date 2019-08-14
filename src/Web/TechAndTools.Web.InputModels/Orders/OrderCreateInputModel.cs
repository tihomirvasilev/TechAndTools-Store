using System.Collections.Generic;
using AutoMapper;
using TechAndTools.Data.Models.Enums;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.ViewModels.Addresses;
using TechAndTools.Web.ViewModels.PaymentMethods;
using TechAndTools.Web.ViewModels.ShoppingCart;
using TechAndTools.Web.ViewModels.Suppliers;

namespace TechAndTools.Web.InputModels.Orders
{
    public class OrderCreateInputModel : IMapTo<OrderServiceModel>, IHaveCustomMappings
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int SupplierId { get; set; }

        public int DeliveryAddressId { get; set; }

        public int PaymentMethodId { get; set; }

        public ShippingTo ShippingTo { get; set; }

        public IEnumerable<AddressViewModel> AddressesViewModels { get; set; }

        public IEnumerable<SupplierViewModel> SuppliersViewModel { get; set; }

        public IEnumerable<PaymentMethodViewModel> PaymentMethodViewModels { get; set; }

        public IEnumerable<ShoppingCartProductViewModel> ShoppingCartProductViewModels { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<OrderCreateInputModel, OrderServiceModel>()
                .ForMember(dest => dest.RecipientPhoneNumber, ops => ops.MapFrom(origin => origin.PhoneNumber))
                .ForMember(dest => dest.Recipient,
                    opts => opts.MapFrom(origin => origin.FirstName + " " + origin.LastName));
        }
    }
}
