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
        public static IHostBuilder CreateHostBuilder(string[] args) =>
     Host.CreateDefaultBuilder(args)
         .ConfigureAppConfiguration((context, config) =>
         {
             var env = context.HostingEnvironment;
             config.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
         })
         .ConfigureServices((hostContext, services) =>
         {
             // Configuración de los DbContexts
             services.AddDbContext<NorthwindContext>(options =>
                 options.UseSqlServer(hostContext.Configuration.GetConnectionString("Northwind"))); // Verifica este nombre

             services.AddDbContext<DbSalesContext>(options =>
                                                   options.UseSqlServer(hostContext.Configuration.GetConnectionString("DWHNorthwind")));

             // Registro de servicios
             services.AddScoped<IDataServiceDwVentas, DataServiceDwVentas>();
             services.AddHostedService<Worker>();
         });

    }
}