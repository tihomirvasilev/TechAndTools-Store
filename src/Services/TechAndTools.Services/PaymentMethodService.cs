using System.Linq;
using TechAndTools.Data;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly TechAndToolsDbContext context;

        public PaymentMethodService(TechAndToolsDbContext context)
        {
            this.context = context;
        }

        public IQueryable<PaymentMethodServiceModel> GetAllPaymentMethods()
        {
            return this.context.PaymentMethods.To<PaymentMethodServiceModel>();
        }
    }
}
