using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services.Models;

namespace TechAndTools.Services.Contracts
{
    public interface IAddressService
    {
        Task<AddressServiceModel> Create(AddressServiceModel addressServiceModel, string username);

        IQueryable<AddressServiceModel> GetAllByUserId(string id);
    }
}
