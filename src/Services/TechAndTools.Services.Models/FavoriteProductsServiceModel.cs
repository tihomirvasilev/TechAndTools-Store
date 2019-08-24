using System;
using System.Collections.Generic;
using System.Text;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class FavoriteProductsServiceModel : IMapFrom<FavoriteProduct>, IMapTo<FavoriteProduct>
    {
        public string Id { get; set; }

        public string UserId { get; set; }
        public TechAndToolsUser User { get; set; }

        public int ProductId { get; set; }
        public ProductServiceModel Product { get; set; }
    }
}
