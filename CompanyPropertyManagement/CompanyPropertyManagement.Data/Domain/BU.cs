using System;
using System.Collections.Generic;

namespace CompanyPropertyManagement.Data.Domain
{
    public class BU
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // Navigation properties
        public virtual ICollection<SeatCode> SeatCodes { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
