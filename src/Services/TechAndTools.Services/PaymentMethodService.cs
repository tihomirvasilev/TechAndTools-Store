using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechAndTools.Data;
using TechAndTools.Data.Models;
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

        public async Task<PaymentMethodServiceModel> GetPaymentMethodByName(string paymentMethodName)
        {
            PaymentMethod method = await this.context.PaymentMethods.FirstOrDefaultAsync(x => x.Name == paymentMethodName);

            if (method == null)
            {
                throw new ArgumentNullException("PaymentMethod is null");
            }

            return method.To<PaymentMethodServiceModel>();
        }
    }
}
