using System;
using System.Collections.Generic;
using System.Text;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.InputModels.Addresses
{
    public class AddressCreateInputModel : IMapTo<AddressServiceModel>
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Quarter { get; set; }

        public string Street { get; set; }

        public int PostCode { get; set; }
    }
}
