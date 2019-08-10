using System;
using System.Collections.Generic;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class OrderServiceModel : IMapFrom<Order>, IMapTo<Order>
    {
        public int Id { get; set; }

        public OrderStatusServiceModel Status { get; set; }

        public PaymentStatusServiceModel PaymentStatus { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal DeliveryPrice { get; set; }

        public string Recipient { get; set; }

        public string RecipientPhoneNumber { get; set; }

        public string InvoiceNumber { get; set; }

        public PaymentMethodServiceModel PaymentMethod { get; set; }
        
        public int DeliveryAddressId { get; set; }
        public virtual AddressServiceModel DeliveryAddress { get; set; }

        public string UserId { get; set; }
        public virtual TechAndToolsUser User { get; set; }

        public virtual ICollection<OrderProductServiceModel> OrderProducts { get; set; }
    }
}
