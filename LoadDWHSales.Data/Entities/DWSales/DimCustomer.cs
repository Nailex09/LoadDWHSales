
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWHSales.Data.Entities.DWSales
{
    [Table("DimCustomer")]
    public class DimCustomer
    {
        [Key]
        public int CustomerKey { get; set; }
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
    }
}
