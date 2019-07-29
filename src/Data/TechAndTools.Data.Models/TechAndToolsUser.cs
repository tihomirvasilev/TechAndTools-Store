using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace TechAndTools.Data.Models
{
    public class TechAndToolsUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }

        public virtual ICollection<FavoriteProduct> FavoriteProducts { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Address> DeliveryAddresses { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}