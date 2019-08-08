using System;
using System.Collections.Generic;
using System.Text;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class ReviewServiceModel : IMapFrom<Review>, IMapTo<Review>
    {
        public string Id { get; set; }

        public string UserId { get; set; }
        public virtual TechAndToolsUser User { get; set; }

        public int ProductId { get; set; }
        public virtual ProductServiceModel Product { get; set; }

        public string Comment { get; set; }

        public double Rating { get; set; }
    }
}
