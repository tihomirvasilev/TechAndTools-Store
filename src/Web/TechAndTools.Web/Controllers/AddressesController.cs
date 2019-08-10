using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.InputModels.Addresses;

namespace TechAndTools.Web.Controllers
{
    public class AddressesController : BaseController
    {
        private readonly IAddressService addressService;

        public AddressesController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddressCreateInputModel addressCreateInputModel)
        {
            await this.addressService.Create(addressCreateInputModel.To<AddressServiceModel>(), this.User.Identity.Name);

            return this.RedirectToAction("Create", "Orders");
        }
    }
}