using System;
using System.Collections.Generic;
using System.Text;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class TechAndToolsUserServiceModel : IMapFrom<TechAndToolsUser>, IMapTo<TechAndToolsUser>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ShoppingCartId { get; set; }
        public ShoppingCartServiceModel ShoppingCart { get; set; }

        public ICollection<FavoriteProductsServiceModel> FavoriteProducts { get; set; }

        public ICollection<ReviewServiceModel> Reviews { get; set; }

        public ICollection<OrderServiceModel> Orders { get; set; }

        public ICollection<AddressServiceModel> DeliveryAddresses { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
