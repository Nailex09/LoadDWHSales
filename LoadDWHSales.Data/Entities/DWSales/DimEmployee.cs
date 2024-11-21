
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LoadDWHSales.Data.Entities.DWSales
{
    [Table("DimEmployee")]
    public class DimEmployee
    {
        [Key]
        public int EmployeeKey { get; set; } // Cambiado de EmployeeID a EmployeeKey
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
    }
}
