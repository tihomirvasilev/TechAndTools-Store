using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class CreateOrderInputModel : IMapTo<OrderServiceModel>, IHaveCustomMappings
    {
        
        [Display(Name = "Име")]
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        public string FirstName { get; set; }
        
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        public string LastName { get; set; }
        
        [Display(Name = "Телефонен номер")]
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        
        [Display(Name = "Куриер")]
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        public int SupplierId { get; set; }
        
        [Display(Name = "Адрес за доставка")]
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        public int AddressId { get; set; }
        
        [Display(Name = "Метод на плащане")]
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        public int PaymentMethodId { get; set; }
        
        [Display(Name = "Доставка до")]
        [Required(ErrorMessage = @"Полето ""{0}"" е задължително.")]
        public ShippingTo ShippingTo { get; set; }

        public IEnumerable<AddressViewModel> AddressesViewModels { get; set; }

        public IEnumerable<SupplierViewModel> SuppliersViewModel { get; set; }

        public IEnumerable<PaymentMethodViewModel> PaymentMethodViewModels { get; set; }

        public IEnumerable<ShoppingCartProductViewModel> ShoppingCartProductViewModels { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<CreateOrderInputModel, OrderServiceModel>()
                .ForMember(dest => dest.RecipientPhoneNumber, ops => ops.MapFrom(origin => origin.PhoneNumber))
                .ForMember(dest => dest.Recipient,
                    opts => opts.MapFrom(origin => origin.FirstName + " " + origin.LastName));
        }
    }
}
