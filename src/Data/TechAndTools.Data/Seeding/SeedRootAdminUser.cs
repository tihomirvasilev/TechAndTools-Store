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
        private const string AdminUsername = "admin";
        private const string AdminFirstName = "Tihomir";
        private const string AdminLastName = "Vasilev";
        private const string AdminEmail = "techandtoolsbg@gmail.com";
        private const string AdminPassword = "asdasd";
        private const string AdminPhoneNumber = "+359999999999";

        public async Task SeedAsync(TechAndToolsDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<TechAndToolsUser>>();

            var hasAdmin = userManager.GetUsersInRoleAsync("Admin").Result.Any();

            if (!hasAdmin)
            {
                TechAndToolsUser admin = new TechAndToolsUser
                {
                    UserName = AdminUsername,
                    FirstName = AdminFirstName,
                    LastName = AdminLastName,
                    Email = AdminEmail,
                    CreatedOn = DateTime.UtcNow,
                    PhoneNumber = AdminPhoneNumber,
                    PhoneNumberConfirmed = true,
                    EmailConfirmed = true,
                    ShoppingCart = new ShoppingCart()
                };

                var password = AdminPassword;

                await userManager.CreateAsync(admin, password);

                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
