using Microsoft.AspNetCore.Identity;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Contracts;

namespace TechAndTools.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<TechAndToolsUser> userManager;
        private readonly TechAndToolsDbContext context;

        public UserService(TechAndToolsDbContext context,
            UserManager<TechAndToolsUser> userManager)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public TechAndToolsUser GetUserByUsername(string username)
        {
            return this.userManager.FindByNameAsync(username).GetAwaiter().GetResult();
        }

        public TechAndToolsUser GetUserById(string userId)
        {
            return this.userManager.FindByIdAsync(userId).GetAwaiter().GetResult();
        }

        public void EditFirstName(TechAndToolsUser user, string firstName)
        {
            if (user == null)
            {
                return;
            }

            user.FirstName = firstName;
            this.context.SaveChanges();
        }

        public void EditLastName(TechAndToolsUser user, string lastName)
        {
            if (user == null)
            {
                return;
            }

            user.LastName = lastName;
            this.context.SaveChanges();
        }
    }
}
