using System;

namespace XamarinClient.Models
{
    public class PropertyReadDto
    {
        public Guid Id { get; set; }
        public string Info { get; set; }
        public string CategoryName { get; set; }
        public string BuName { get; set; }
        public bool IsChecked { get; set; }
    }
}
