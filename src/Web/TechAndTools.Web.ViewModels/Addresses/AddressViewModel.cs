using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.ViewModels.Addresses
{
    public class AddressViewModel : IMapFrom<AddressServiceModel>, IMapFrom<Address>
    {
        public int Id { get; set; }
        
        public string City { get; set; }

        public string CityAddress { get; set; }

        public int PostCode { get; set; }
    }
}
