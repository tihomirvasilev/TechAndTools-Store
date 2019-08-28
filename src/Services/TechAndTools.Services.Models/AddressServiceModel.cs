using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class AddressServiceModel : IMapFrom<Address>, IMapTo<Address>
    {
        public int Id { get; set; }

        public string TechAndToolsUserId { get; set; }
        
        public string City { get; set; }

        public string CityAddress { get; set; }

        public int PostCode { get; set; }
    }
}
