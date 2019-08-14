using System;
using System.Collections.Generic;
using System.Text;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class ShoppingCartServiceModel : IMapFrom<ShoppingCart>, IMapTo<ShoppingCart>
    {
        public int Id { get; set; }

        public TechAndToolsUser User { get; set; }

        public ICollection<ShoppingCartProductServiceModel> ShoppingCartProducts { get; set; }
    }
}
