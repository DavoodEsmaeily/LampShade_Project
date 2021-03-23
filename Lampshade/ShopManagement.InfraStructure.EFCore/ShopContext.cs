using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.InfraStructure.EFCore.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.InfraStructure.EFCore
{
   public class ShopContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assambly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assambly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
