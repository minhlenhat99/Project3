﻿using System;

namespace XamarinClient.Models
{
    public class InventoryCreateDto
    {
        public DateTime CheckDate { get; set; }
        public string Report { get; set; }
        public Guid UserId { get; set; }
        public Guid BuId { get; set; }
    }
}
