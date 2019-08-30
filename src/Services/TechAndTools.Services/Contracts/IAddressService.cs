using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services.Models;

namespace TechAndTools.Services.Contracts
{
    public interface IAddressService
    {
        Task<AddressServiceModel> CreateAsync(AddressServiceModel addressServiceModel, string username);

        Task<bool> DeleteByIdAsync(int addressId);

        IQueryable<AddressServiceModel> GetAllByUserId(string userId);
    }
}
