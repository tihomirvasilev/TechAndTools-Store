using System;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.ViewModels.Orders
{
    public class UnprocessedОrderViewModel : IMapFrom<OrderServiceModel>
    {
        public int Id { get; set; }

        public string PaymentStatusName { get; set; }

        public DateTime OrderDate { get; set; }

        public string PaymentMethodName { get; set; }
    }
}
