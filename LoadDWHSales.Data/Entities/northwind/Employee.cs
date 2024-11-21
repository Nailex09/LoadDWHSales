
using Microsoft.EntityFrameworkCore;
using LoadDWHSales.Data.Context;

namespace LoadDWHSales.Data.Entities.Northwind
{
    public class Employee
    {
        public int EmployeeID { get; set; } // ID único del empleado
        public string FirstName { get; set; } // Nombre del empleado
        public string LastName { get; set; } // Apellido del empleado
        public string Title { get; set; } // Título del puesto
        public DateTime? BirthDate { get; set; } // Fecha de nacimiento
        public DateTime? HireDate { get; set; } // Fecha de contratación
        public string Address { get; set; } // Dirección del empleado
        public string City { get; set; } // Ciudad del empleado
        public string Region { get; set; } // Región del empleado
        public string PostalCode { get; set; } // Código postal
        public string Country { get; set; } // País
        public string HomePhone { get; set; } // Teléfono
        public string Extension { get; set; } // Extensión telefónica
        public byte[] Photo { get; set; } // Foto (si aplica)
        public string Notes { get; set; } // Notas adicionales
    }
}
