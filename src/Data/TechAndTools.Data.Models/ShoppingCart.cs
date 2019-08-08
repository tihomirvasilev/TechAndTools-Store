using System.Collections.Generic;

namespace TechAndTools.Data.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public virtual TechAndToolsUser User { get; set; }

        public virtual ICollection<ShoppingCartProduct> ShoppingCartProducts { get; set; }
    }
}