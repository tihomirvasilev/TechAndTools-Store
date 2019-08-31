using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TechAndTools.Commons.Constants;
using TechAndTools.Data.Models;

namespace TechAndTools.Data.Seeding
{
    public class PaymentTypesSeeder : ISeeder
    {
        public async Task SeedAsync(TechAndToolsDbContext dbContext, IServiceProvider serviceProvider)
        {
            bool hasPaymentTypes = await dbContext.PaymentMethods.AnyAsync();

            if (!hasPaymentTypes)
            {
                await SeedPaymentTypesAsync(GlobalConstants.CashOnDeliver, dbContext);

                await dbContext.SaveChangesAsync();
            }
        }

        private static async Task SeedPaymentTypesAsync(string paymentTypeName, TechAndToolsDbContext dbContext)
        {
            var paymentType = new PaymentMethod { Name = paymentTypeName };

            await dbContext.PaymentMethods.AddAsync(paymentType);
        }
    }
}
