using System;
using System.Collections.Generic;

namespace TechAndTools.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ExpectedDeliveryDate { get; set; }

        public DateTime? ShippingDate { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal DeliveryPrice { get; set; }

        public string Recipient { get; set; }

        public string RecipientPhoneNumber { get; set; }

        public int PaymentMethodId { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }

        public int OrderStatusId { get; set; }
        public virtual OrderStatus Status { get; set; }

        public int PaymentStatusId { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }

        public int DeliveryAddressId { get; set; }
        public virtual Address DeliveryAddress { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public string UserId { get; set; }
        public virtual TechAndToolsUser User { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
