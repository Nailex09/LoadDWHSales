
using Microsoft.EntityFrameworkCore;
using LoadDWHSales.Data.Context;

namespace LoadDWHSales.Data.Entities.northwind
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
        {

        }
        #region"Db sets"
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        #endregion
    }
    }
