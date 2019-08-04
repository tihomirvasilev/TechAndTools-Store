using System;
using System.Collections.Generic;
using System.Text;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class PaymentTypeServiceModel : IMapFrom<PaymentType>, IMapTo<PaymentType>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
