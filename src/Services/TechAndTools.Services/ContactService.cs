using System;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Services
{
    public class ContactService : IContactService
    {
        private readonly TechAndToolsDbContext context;

        public ContactService(TechAndToolsDbContext context)
        {
            this.context = context;
        }

        public async Task<ContactServiceModel> CreateAsync(ContactServiceModel serviceModel)
        {
            Contact contact = serviceModel.To<Contact>();

            await this.context.Contacts.AddAsync(contact);
            await this.context.SaveChangesAsync();

            return contact.To<ContactServiceModel>();
        }

        public async Task<bool> DeleteAsync(int contactId)
        {
            Contact contact = this.context.Contacts.Find(contactId);

            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }

            this.context.Contacts.Remove(contact);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> MarkAsRead(int contactId)
        {
            Contact contact = this.context.Contacts.Find(contactId);

            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }

            contact.MarkAsRead = true;

            this.context.Contacts.Update(contact);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<ContactServiceModel> GetAllContacts()
        {
            return this.context.Contacts.To<ContactServiceModel>();
        }
    }
}
