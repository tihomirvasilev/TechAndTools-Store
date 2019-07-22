using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using TechAndTools.Data.Models.Contracts;

namespace TechAndTools.Data.Models
{
    public class TechAndToolsUser : IdentityUser, IAuditInfo
    {
        public string ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }

        public virtual ICollection<FavoriteProduct> FavoriteProducts { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<DeliveryAddress> DeliveryAddresses { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}