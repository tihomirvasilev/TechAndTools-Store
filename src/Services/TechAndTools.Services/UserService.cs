using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
