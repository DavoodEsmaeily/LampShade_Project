﻿namespace InventoryManagement.Application.Contract.Inventory
{
    public  class OperationLogViewModel
    {
        public long Id { get;  set; }
        public bool Operation { get;  set; }
        public long Count { get;  set; }
        public long OperatorId { get;  set; }
        public string Operator { get; set; }
        public long CurrentCount { get;  set; }
        public string OperationDate { get;  set; }
        public string Description { get;  set; }
        public long OrderId { get;  set; }
    }
}