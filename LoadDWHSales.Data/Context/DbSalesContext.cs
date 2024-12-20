﻿using LoadDWHSales.Data.Entities.DWSales;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LoadDWHSales.Data.Context
{
    public class DbSalesContext : DbContext
    {
        public DbSalesContext(DbContextOptions<DbSalesContext> options) : base(options) { }

        #region "Db Sets"
        public DbSet<DimProductCategory> ProductCategories { get; set; }
        public DbSet<DimEmployees> Employees { get; set; }
        public DbSet<DimCustomer> Customers { get; set; }
        public DbSet<DimShipper> DimShippers { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DimProductCategory>().HasNoKey();
        }

    }
}
