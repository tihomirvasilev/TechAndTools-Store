using System;
using System.Collections.Generic;
using System.Text;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class PaymentStatusServiceModel : IMapFrom<PaymentStatus>, IMapTo<PaymentStatus>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
