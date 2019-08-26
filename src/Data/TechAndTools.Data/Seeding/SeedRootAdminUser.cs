using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Data.Models;

namespace TechAndTools.Data.Seeding
{
    public class SeedRootAdminUser : ISeeder
    {
        public async Task SeedAsync(TechAndToolsDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<TechAndToolsUser>>();

            var hasAdmin = userManager.GetUsersInRoleAsync("Admin").Result.Any();

            if (!hasAdmin)
            {
                TechAndToolsUser admin = new TechAndToolsUser
                {
                    UserName = "admin",
                    FirstName = "Tihomir",
                    LastName = "Vasilev",
                    Email = "admin@admin.com",
                    ShoppingCart = new ShoppingCart()
                };

                var password = "123456";

                await userManager.CreateAsync(admin, password);

                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
