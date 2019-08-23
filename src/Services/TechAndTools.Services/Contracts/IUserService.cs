using TechAndTools.Data.Models;

namespace TechAndTools.Services.Contracts
{
    public interface IUserService
    {
        TechAndToolsUser GetUserByUsername(string username);

        TechAndToolsUser GetUserById(string userId);

        void EditFirstName(TechAndToolsUser user, string firstName);

        void EditLastName(TechAndToolsUser user, string lastName);
    }
}
