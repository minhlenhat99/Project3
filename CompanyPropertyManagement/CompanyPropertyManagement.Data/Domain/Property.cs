using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyPropertyManagement.Data.Domain
{
    public class Property
    {
        // 2 truong nua: truong anh va truong QR code
        public Guid Id { get; set; }
        public string Info { get; set; }
        public Guid CategoryId { get; set; }
        public string SeatCodeId { get; set; }
        // Navigation property
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [ForeignKey("SeatCodeId")]
        public virtual SeatCode SeatCode { get; set; }
    }
}
