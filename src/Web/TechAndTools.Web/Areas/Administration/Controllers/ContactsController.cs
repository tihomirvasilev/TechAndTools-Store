using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.ViewModels.Contacts;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    public class ContactsController : AdministrationController
    {
        private readonly IContactService contactService;

        public ContactsController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public IActionResult All(int id)
        {
            var contacts = this.contactService.GetAllContacts().ToList();

            var currentContact = contacts.FirstOrDefault(x => x.Id == id) ?? contacts.FirstOrDefault();

            this.contactService.MarkAsRead(id);

            var userRequestsViewModels = contacts.Select(x => x.To<ContactViewModel>()).ToList();

            var currentContactViewModel = currentContact.To<ContactViewModel>();

            var viewModel = new ContactAllViewModel
            {
                ContactViewModels = userRequestsViewModels,
                ContactViewModel = currentContactViewModel
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userRequests = await this.contactService.DeleteAsync(id);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Seen(int id)
        {
            this.contactService.MarkAsRead(id);
            
            return RedirectToAction(nameof(All));
        }
    }
}