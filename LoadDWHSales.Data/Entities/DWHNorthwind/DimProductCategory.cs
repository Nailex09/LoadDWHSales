using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWHSales.Data.Entities.DWSales
{
    [Table("DimProductCategory")]
    public class DimProductCategory
    {
        [Key] // Esto define la clave primaria
        public int ProductKey { get; set; }
        public int Productid { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
    }
}
