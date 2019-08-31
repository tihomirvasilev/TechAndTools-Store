using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services.Models;

namespace TechAndTools.Services.Contracts
{
    public interface IContactService
    {
        Task<ContactServiceModel> CreateAsync(ContactServiceModel serviceModel);

        Task<bool> DeleteAsync(int contactId);

        Task<bool> MarkAsRead(int contactId);

        IQueryable<ContactServiceModel> GetAllContacts();
    }
}
