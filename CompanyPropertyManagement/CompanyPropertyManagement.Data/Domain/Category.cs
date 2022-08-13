using System;
using System.Collections.Generic;

namespace CompanyPropertyManagement.Data.Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // Navigation Properties
        public virtual ICollection<Property> Properties { get; set; }
    }
}
