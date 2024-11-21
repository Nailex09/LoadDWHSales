using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWHSales.Data.Entities.northwind
{
    public class Product
    {
        public int ProductID { get; set; } // ID único del producto
        public string ProductName { get; set; }
        public int CategoryID { get; set; } // FK hacia la tabla Category
    }

}
