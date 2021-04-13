using _0_Framework.Application;
using _0_Framework.InfraStructure;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using ShopManagement.InfraStructure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Infrastracture.EFCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _context;

        public InventoryRepository(ShopContext shopManagement, InventoryContext context) : base(context)
        {
            _shopContext = shopManagement;
            _context = context;
        }

        public Inventory GetBy(long productId)
        {
            return _context.Inventory.FirstOrDefault(x => x.ProductId == productId);
        }

        public EditInventory GetDetails(long id)
        {
            return _context.Inventory.Select(x => new EditInventory
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<OperationLogViewModel> GetOperationLog(long inventoryId)
        {
            var inventory = _context.Inventory.FirstOrDefault(x => x.Id == inventoryId);

            return inventory.Operations.Select(x => new OperationLogViewModel
            {
                Id = x.Id,
                Count = x.Count,
                CurrentCount = x.CurrentCount,
                Operation = x.Operation,
                OperatorId = x.OperatorId,
                OperationDate = x.OperationDate.ToFarsi(),
                Operator  = "مدیر سیستم",
                Description = x.Description,
                OrderId = x.OrderId
            }).OrderByDescending(x => x.Id).ToList();
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();

            var query = _context.Inventory.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                InStock = x.InStock,
                ProductId = x.ProductId,
                CurrentCount = x.CalculateCurrentCount(),
                UnitPrice = x.UnitPrice
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (searchModel.InStock)
                query = query.Where(x => !x.InStock);


            var inventory = query.OrderByDescending(x => x.Id).ToList();

            inventory.ForEach(inventory => inventory.Product = products.FirstOrDefault(x => x.Id == inventory.ProductId)?.Name);

            return inventory;
        }
    }
}
