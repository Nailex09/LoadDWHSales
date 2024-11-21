using LoadDWHSales.Data.Context;
using LoadDWHSales.Data.DataServiceDwVentas;
using LoadDWHSales.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LoadDWHSales.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly IServiceScopeFactory _scopeFactory;

        public Worker(ILogger<Worker> logger, IConfiguration configuration, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting data load process...");
            using var scope = _scopeFactory.CreateScope();
            var dataService = scope.ServiceProvider.GetRequiredService<IDataServiceDwVentas>();

            var result = await dataService.LoadDHW();

            if (result.Success)
            {
                _logger.LogInformation("Data loading completed successfully.");
            }
            else
            {
                _logger.LogError($"Data loading failed: {result.Message}");
            }
        }


    }
}
