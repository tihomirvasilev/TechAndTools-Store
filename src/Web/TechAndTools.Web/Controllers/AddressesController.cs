using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.InputModels.Addresses;
using TechAndTools.Web.ViewModels.Addresses;

namespace TechAndTools.Web.Controllers
{
    public class AddressesController : BaseController
    {
        private readonly IAddressService addressService;

        public AddressesController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddressCreateInputModel addressCreateInputModel)
        {
            await this.addressService.CreateAsync(addressCreateInputModel.To<AddressServiceModel>(), this.User.Identity.Name);

            return this.RedirectToAction("Create", "Orders");
        }

        public async Task<IActionResult> MyAddresses()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModels = await this.addressService.GetAllByUserId(userId).To<AddressViewModel>().ToListAsync();

            return this.View(viewModels);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.addressService.DeleteById(id);

            return this.RedirectToAction("MyAddresses", "Addresses");
        }
    }
}