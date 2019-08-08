using TechAndTools.Data.Models;

namespace TechAndTools.Services
{
    public interface IUserService
    {
        TechAndToolsUser GetUserByUsername(string username);
    }
}
