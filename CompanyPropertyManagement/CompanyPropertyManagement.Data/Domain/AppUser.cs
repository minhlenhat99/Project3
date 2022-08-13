using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CompanyPropertyManagement.Data.Domain
{
    public class AppUser : IdentityUser<Guid>
    {
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
