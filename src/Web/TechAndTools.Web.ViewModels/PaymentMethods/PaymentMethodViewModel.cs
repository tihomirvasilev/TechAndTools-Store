using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.ViewModels.PaymentMethods
{
    public class PaymentMethodViewModel : IMapFrom<PaymentMethodServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
