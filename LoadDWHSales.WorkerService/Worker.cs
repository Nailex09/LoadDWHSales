using LoadDWHSales.Data.Context;
using LoadDWHSales.Data.DataServiceDwVentas;
using LoadDWHSales.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LoadDWHSales.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;  // Inyección de IServiceProvider para crear scope
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Crear un nuevo scope para resolver dependencias scoped
            using (var scope = _serviceProvider.CreateScope())
            {
                // Resolver IDataServiceDwVentas dentro de este scope
                var dataService = scope.ServiceProvider.GetRequiredService<IDataServiceDwVentas>();

                try
                {
                    _logger.LogInformation("Starting data load process...");

                    // Llamar al servicio para cargar los datos
                    var result = await dataService.LoadDHW();
                    if (result.Success)
                    {
                        _logger.LogInformation("Data load completed successfully.");
                    }
                    else
                    {
                        _logger.LogError($"Data load failed: {result.Message}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error during data load: {ex.Message}");
                }
            }
        }
    }
}



