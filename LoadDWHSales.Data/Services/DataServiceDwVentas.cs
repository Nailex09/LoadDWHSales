using LoadDWHSales.Data.Context;
using LoadDWHSales.Data.Entities.DWSales;
using LoadDWHSales.Data.Interfaces;
using LoadDWHSales.Data.Results;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LoadDWHSales.Data.DataServiceDwVentas
{
    public class DataServiceDwVentas : IDataServiceDwVentas
    {
        private readonly DbSalesContext _dbSalesContext;
        private readonly NorthwindContext _northwindContext;

        public DataServiceDwVentas(NorthwindContext northwindContext, DbSalesContext dbSalesContext)
        {
            _dbSalesContext = dbSalesContext;
            _northwindContext = northwindContext;
        }

        public async Task<OperactionResult> LoadDHW()
        {
            OperactionResult result = new OperactionResult();

            try
            {
                await LimpiarDatos();
                await LoadDimEmployees();
                await LoadDimProductCategory();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error during data load: {ex.Message}";
            }
            return result;
        }

        private async Task LimpiarDatos()
        {
            var query = "EXEC dbo.LimpiarDatos";
            await _dbSalesContext.Database.ExecuteSqlRawAsync(query);
        }


        private async Task<OperactionResult> LoadDimEmployees()
        {
            var result = new OperactionResult();
            try
            {
                var employees = await _northwindContext.Employees
                    .AsNoTracking()
                    .Select(emp => new DimEmployees
                    {
                        EmployeeID = emp.EmployeeID,
                        EmployeeName = $"{emp.FirstName} {emp.LastName}"
                    })
                    .ToListAsync();

                await _dbSalesContext.Employees.AddRangeAsync(employees);
                await _dbSalesContext.SaveChangesAsync();

                result.Success = true;
                result.Message = "DimEmployees loaded successfully.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error loading DimEmployees: {ex.Message}";
            }
            return result;
        }




        private async Task<OperactionResult> LoadDimProductCategory()
        {
            var result = new OperactionResult();
            try
            {
                var productCategories = await (from product in _northwindContext.Products
                                               join category in _northwindContext.Categories
                                               on product.CategoryID equals category.CategoryID
                                               select new DimProductCategory()
                                               {
                                                   // Asegurarse de que ProductKey sea la clave primaria
                                                   CategoryID = category.CategoryID,
                                                   ProductName = product.ProductName,
                                                   CategoryName = category.CategoryName,
                                                   Productid = product.ProductID

                                               })
                                               .AsNoTracking()
                                               .ToListAsync();

                await _dbSalesContext.ProductCategories.AddRangeAsync(productCategories);
                await _dbSalesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error loading DimProductCategory: {ex.Message}";
            }
            return result;
        }




        private async Task<OperactionResult> LoadDimCustomers()
        {
            var result = new OperactionResult();
            try
            {
                var customers = await _northwindContext.Customers
                    .AsNoTracking()
                    .Select(c => new DimCustomer
                    {
                        CustomerID = c.CustomerId, // Reemplazar si el campo tiene un nombre diferente
                        CompanyName = c.CompanyName
                    })
                    .ToListAsync();

                await _dbSalesContext.Customers.AddRangeAsync(customers);
                await _dbSalesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error loading DimCustomers: {ex.Message}";
            }
            return result;
        }





        private async Task<OperactionResult> LoadDimShippers()
        {
            var result = new OperactionResult();
            try
            {
                var shippers = await _northwindContext.Shippers
                    .AsNoTracking()
                    .Select(ship => new DimShipper
                    {
                        ShipperID = ship.ShipperID, // Confirma que este sea el campo correcto
                        ShipperName = ship.ShipperName // Confirma que este sea el campo correcto
                    })
                    .ToListAsync();

                await _dbSalesContext.DimShippers.AddRangeAsync(shippers);
                await _dbSalesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error loading DimShippers: {ex.Message}";
            }
            return result;
        }

    }
}
