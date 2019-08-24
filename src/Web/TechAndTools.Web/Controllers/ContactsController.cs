using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.InputModels.Contacts;

namespace TechAndTools.Web.Controllers
{
    public class ContactsController : BaseController
    {
        private readonly IContactService contactService;

        public ContactsController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public IActionResult Contacts()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendContact(CreateContactInputModel inputModel)
        {
            await this.contactService.CreateAsync(inputModel.To<ContactServiceModel>());

            return this.Redirect("/");
        }
    }
}
