﻿namespace InventoryManagement.Application.Contract.Inventory
{
    public class InventoryViewModel
    {
        public long Id { get; set; }
        public string Product { get; set; }
        public long ProductId { get; set; }
        public double CurrentCount { get; set; }
        public string CreationDate { get; set; }
        public bool InStock { get; set; }
        public double UnitPrice { get; set; }
    }
}
