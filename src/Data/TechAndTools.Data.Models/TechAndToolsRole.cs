using System;
using Microsoft.AspNetCore.Identity;
using TechAndTools.Data.Models.Contracts;

namespace TechAndTools.Data.Models
{
    public class TechAndToolsRole : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
