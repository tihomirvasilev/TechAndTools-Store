using TechAndTools.Data.Models;

namespace TechAndTools.Services.Contracts
{
    public interface IUserService
    {
        TechAndToolsUser GetUserByUsername(string username);
    }
}
