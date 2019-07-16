namespace TechAndTools.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using TechAndTools.Data.Models.Contracts;

    public class TechAndToolsRole : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
