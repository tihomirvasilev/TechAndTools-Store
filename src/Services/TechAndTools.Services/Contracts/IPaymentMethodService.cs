using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechAndTools.Services.Models;

namespace TechAndTools.Services.Contracts
{
    public interface IPaymentMethodService
    {
        IQueryable<PaymentMethodServiceModel> GetAllPaymentMethods();

        Task<PaymentMethodServiceModel> GetPaymentMethodByName(string paymentMethodName);
    }
}
