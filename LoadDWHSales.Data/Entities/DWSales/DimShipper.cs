
using LoadDWHSales.Data.Entities.northwind;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWHSales.Data.Entities.DWSales
{
    [Table("DimShipper")]
    public class DimShipper
    {
        [Key]
        public int ShipperKey { get; set; } // Clave primaria en el DWH
        public int ShipperID { get; set; } // ID original del transportista
        public string ShipperName { get; set; } // Nombre de la compañía
    }

}
