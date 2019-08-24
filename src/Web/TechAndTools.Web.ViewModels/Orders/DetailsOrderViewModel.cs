using System.Collections.Generic;
using AutoMapper;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.ViewModels.Orders
{
    public class DetailsOrderViewModel : IMapFrom<OrderServiceModel>, IHaveCustomMappings
    {
        public string Recipient { get; set; }
        
        public string RecipientPhoneNumber { get; set; }

        public string DeliveryAddress { get; set; }

        public string SupplierName { get; set; }

        public string PaymentStatusName { get; set; }

        public string OrderStatusName { get; set; }

        public string PaymentMethodName { get; set; }

        public IEnumerable<OrderProductViewModel> OrderProducts { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<OrderServiceModel, DetailsOrderViewModel>()
                .ForMember(dest => dest.RecipientPhoneNumber, org => org.MapFrom(src => src.RecipientPhoneNumber))
                .ForMember(dest => dest.DeliveryAddress,
                    org => org.MapFrom(src =>
                        src.Address.Country + " " + src.Address.City + " " +
                        src.Address.Street))
                .ForMember(dest => dest.SupplierName, org => org.MapFrom(src => src.Supplier.Name))
                .ForMember(dest => dest.PaymentStatusName, org => org.MapFrom(src => src.PaymentStatus.Name))
                .ForMember(dest => dest.OrderStatusName, org => org.MapFrom(src => src.OrderStatus.Name))
                .ForMember(dest => dest.PaymentMethodName, org => org.MapFrom(src => src.PaymentMethod.Name));
        }
    }
}
