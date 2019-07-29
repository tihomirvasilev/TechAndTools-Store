using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TechAndTools.Data.Models;

namespace TechAndTools.Data.Seeding
{
    public class PaymentStatusesSeeder : ISeeder
    {
        public async Task SeedAsync(TechAndToolsDbContext dbContext, IServiceProvider serviceProvider)
        {
            bool hasPaymentStatuses = await dbContext.PaymentStatuses.AnyAsync();

            if (!hasPaymentStatuses)
            {
                await SeedPaymentStatusAsync("Unpaid", dbContext);
                await SeedPaymentStatusAsync("Paid", dbContext);
            }
        }

        private static async Task SeedPaymentStatusAsync(string paymentName, TechAndToolsDbContext dbContext)
        {
            var paymentStatus = new PaymentStatus { Name = paymentName };

            await dbContext.PaymentStatuses.AddAsync(paymentStatus);
            await dbContext.SaveChangesAsync();
        }
    }
}
