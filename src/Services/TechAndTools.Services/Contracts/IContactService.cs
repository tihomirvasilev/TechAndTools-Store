using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services.Models;

namespace TechAndTools.Services.Contracts
{
    public interface IContactService
    {
        Task<ContactServiceModel> CreateAsync(ContactServiceModel serviceModel);

        Task<bool> DeleteAsync(int contactId);

        bool Archive(int contactId);

        IQueryable<ContactServiceModel> GetAllContacts();

        IQueryable<ContactServiceModel> GetAllArchivedContacts();
    }
}
