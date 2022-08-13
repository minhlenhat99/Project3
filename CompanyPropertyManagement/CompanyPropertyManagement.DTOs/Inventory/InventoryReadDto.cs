using System;

namespace CompanyPropertyManagement.DTOs.Inventory
{
    public class InventoryReadDto
    {
        public Guid Id { get; set; }
        public DateTime CheckDate { get; set; }
        public string Report { get; set; }
        //public Guid UserId { get; set; }
        public string UserName { get; set; }
        //public Guid BuId { get; set; }
        public string BuName { get; set; }
    }
}
