using System;
using System.Collections.Generic;
using System.Text;

namespace TechAndTools.Web.ViewModels.Contacts
{
    public class ContactAllViewModel
    {
        public IList<ContactViewModel> ContactViewModels { get; set; }

        public ContactViewModel ContactViewModel  { get; set; }
    }
}
