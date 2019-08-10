using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.ViewModels.Addresses
{
    public class AddressViewModel : IMapFrom<AddressServiceModel>, IMapFrom<Address>
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Quarter { get; set; }

        public string Street { get; set; }

        public int PostCode { get; set; }
    }
}
