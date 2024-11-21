
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LoadDWHSales.Data.Entities.DWSales
{
    [Table("DimEmployees")]
    public class DimEmployees
    {
        [Key]
        public int EmployeeKey { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
    }
}