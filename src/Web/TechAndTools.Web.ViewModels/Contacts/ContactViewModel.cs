using System;
using System.Collections.Generic;
using System.Text;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.ViewModels.Contacts
{
    public class ContactViewModel : IMapFrom<ContactServiceModel>
    {
        public int Id { get; set; }

        public string FullName { get;set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Message { get; set; }

        public bool MarkAsRead { get; set; }
    }
}
