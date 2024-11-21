using LoadDWHSales.Data.Context;
using LoadDWHSales.Data.DataServiceDwVentas;
using LoadDWHSales.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LoadDWHSales.WorkerService
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {

                services.AddDbContextPool<NorthwindContext>(options =>
                                                            options.UseSqlServer(hostContext.Configuration.GetConnectionString("Northwind")));

                services.AddDbContextPool<DbSalesContext>(options =>
                                                          options.UseSqlServer(hostContext.Configuration.GetConnectionString("DWHNorthwind")));

                services.AddScoped<IDataServiceDwVentas, DataServiceDwVentas>();
                services.AddHostedService<Worker>();
            });
        }
    }
}