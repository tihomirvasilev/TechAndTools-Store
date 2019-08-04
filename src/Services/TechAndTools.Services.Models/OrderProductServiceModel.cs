using System;
using System.Collections.Generic;
using System.Text;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class OrderProductServiceModel : IMapFrom<OrderProduct>, IMapTo<OrderProduct>
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public OrderServiceModel Order { get; set; }

        public int ProductId { get; set; }
        public ProductServiceModel Product { get; set; }

        public int Quantity { get; set; }
    }
}
