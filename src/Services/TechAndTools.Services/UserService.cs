using System;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Contracts;

namespace TechAndTools.Services
{
    public class UserService : IUserService
    {
        private readonly TechAndToolsDbContext context;

        public UserService(TechAndToolsDbContext context)
        {
            this.context = context;
        }

        public TechAndToolsUser GetUserByUsername(string username)
        {
            return this.context.Users.FirstOrDefault(x => x.UserName == username);
        }

        public TechAndToolsUser GetUserById(string userId)
        {
            return this.context.Users.Find(userId);
        }

        public async Task<bool> EditFirstName(TechAndToolsUser user, string firstName)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (firstName.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            user.FirstName = firstName;
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> EditLastName(TechAndToolsUser user, string lastName)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (lastName.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(user));
            }

            user.LastName = lastName;
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }
    }
}
