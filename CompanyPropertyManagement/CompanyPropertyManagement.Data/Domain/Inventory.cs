using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyPropertyManagement.Data.Domain
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public DateTime CheckDate { get; set; }
        public string Report { get; set; }
        public Guid UserId { get; set; }
        public Guid BuId { get; set; }
        // Navigation Property
        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }
        [ForeignKey("BuId")]
        public virtual BU BU { get; set; }
    }
}
