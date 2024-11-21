
using LoadDWHSales.Data.Results;
namespace LoadDWHSales.Data.Interfaces
{
    public interface IDataServiceDwVentas
    {
        Task<OperactionResult> LoadDHW();
    }
}
