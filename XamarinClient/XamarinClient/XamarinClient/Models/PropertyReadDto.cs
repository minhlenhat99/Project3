using System;

namespace XamarinClient.Models
{
    public class PropertyReadDto
    {
        public Guid Id { get; set; }
        public string Info { get; set; }
        public string CategoryName { get; set; }
        public string BuName { get; set; }
        public Guid BuId { get; set; }
        public string SeatCode { get; set; }
        public bool IsChecked { get; set; }
        public string ImageSource { 
            get
            {
                return $"{CategoryName}.jpg";
            } 
        }
    }
}
