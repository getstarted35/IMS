﻿using IMS.CoreBusiness;
using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModels
{
    public class PurchaseViewModel
    {
        [Required]
        public string PurchaseOrder { get; set; }

        [Required]
        public int InventoryId { get; set; }

        [Required]
        public string InventoryName { get; set; }

        [Required]
        [Range(minimum:1, maximum:int.MaxValue, ErrorMessage = "miktar 1'den büyük olmalı")]
        public int QuantityToPurchase { get; set; } 

        public double InventoryPrice { get; set; }
    }
}
