using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Services
{
    public class AddressService : IAddressService
    {
        private readonly TechAndToolsDbContext context;
        private readonly IUserService userService;

        public AddressService(TechAndToolsDbContext context,
            IUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }

        public async Task<AddressServiceModel> Create(AddressServiceModel addressServiceModel, string username)
        {
            var address = addressServiceModel.To<Address>();

            var user = this.userService.GetUserByUsername(username);

            user.Addresses.Add(address);
            await this.context.Addresses.AddAsync(address);
            await this.context.SaveChangesAsync();
            
            return address.To<AddressServiceModel>();
        }

        public IQueryable<AddressServiceModel> GetAllByUserId(string id)
        {
            return this.context.Addresses.Where(x => x.TechAndToolsUserId == id).To<AddressServiceModel>();
        }
    }
}
