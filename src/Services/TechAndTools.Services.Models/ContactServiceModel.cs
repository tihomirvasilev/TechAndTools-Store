using System;
using System.Collections.Generic;
using System.Text;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class ContactServiceModel : IMapFrom<Contact>, IMapTo<Contact>
    {
        public int Id { get; set; }

        public string FullName { get;set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Message { get; set; }

        public bool MarkAsRead { get; set; }
    }
}
