using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TechAndTools.Data.Models;

namespace TechAndTools.Data.Seeding
{
    public class PaymentTypesSeeder : ISeeder
    {
        public async Task SeedAsync(TechAndToolsDbContext dbContext, IServiceProvider serviceProvider)
        {
            bool hasPaymentTypes = await dbContext.PaymentTypes.AnyAsync();

            if (!hasPaymentTypes)
            {
                await SeedPaymentTypesAsync("CashОnDelivery", dbContext);
                await SeedPaymentTypesAsync("PayPal", dbContext);
                await SeedPaymentTypesAsync("EPay", dbContext);

                await dbContext.SaveChangesAsync();
            }
        }

        private static async Task SeedPaymentTypesAsync(string paymentTypeName, TechAndToolsDbContext dbContext)
        {
            var paymentType = new PaymentType { Name = paymentTypeName };

            await dbContext.PaymentTypes.AddAsync(paymentType);
        }
    }
}
