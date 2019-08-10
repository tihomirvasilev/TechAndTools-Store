using Microsoft.AspNetCore.Identity;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Contracts;

namespace TechAndTools.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<TechAndToolsUser> userManager;
        private readonly TechAndToolsDbContext db;

        public UserService(TechAndToolsDbContext db,
            UserManager<TechAndToolsUser> userManager)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public TechAndToolsUser GetUserByUsername(string username)
        {
            return this.userManager.FindByNameAsync(username).GetAwaiter().GetResult();
        }
    }
}
