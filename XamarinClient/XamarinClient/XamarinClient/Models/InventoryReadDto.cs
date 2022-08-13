using System;

namespace XamarinClient.Models
{
    public class InventoryReadDto
    {
        public Guid Id { get; set; }
        public DateTime CheckDate { get; set; }
        public string Report { get; set; }
        public string UserName { get; set; }
        public string BuName { get; set; }
    }
}
