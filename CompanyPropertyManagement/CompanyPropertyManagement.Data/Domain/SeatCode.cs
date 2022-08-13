using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyPropertyManagement.Data.Domain
{
    public class SeatCode
    {
        public string Id { get; set; }
        public Guid BuId { get; set; }
        // Navigation properties
        public virtual ICollection<Property> Properties { get; set; }
        [ForeignKey("BuId")]
        public virtual BU BU { get; set; }
    }
}
