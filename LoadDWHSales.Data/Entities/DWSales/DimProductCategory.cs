
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWHSales.Data.Entities.DWSales
{
    public class DimProductCategory
    {
        public int Productkey { get; set; }
        public int Productid { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }

    }
}
