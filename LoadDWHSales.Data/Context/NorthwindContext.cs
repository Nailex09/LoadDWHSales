using LoadDWHSales.Data.Entities.DWSales;
using LoadDWHSales.Data.Entities.northwind;
using Microsoft.EntityFrameworkCore;

namespace LoadDWHSales.Data.Context
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options) 
        {

        }
        #region "Db Sets"
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<DimEmployee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shipper> Shippers { get; set; }

        #endregion
    }
}
