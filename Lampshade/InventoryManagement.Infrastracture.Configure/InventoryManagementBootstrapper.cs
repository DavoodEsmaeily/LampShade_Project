using InventoryManagement.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastracture.EFCore;
using InventoryManagement.Infrastracture.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InventoryManagement.Infrastracture.Configure
{
    public class InventoryManagementBootstrapper 
    {
        public static void Configure(IServiceCollection  services , string connectionString)
        {
            services.AddTransient<IInventoryRepository, InventoryRepository>();

            services.AddTransient<IInventoryApplication, InventoryApplication>();

            services.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
