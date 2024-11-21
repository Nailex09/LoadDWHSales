using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWHSales.Data.Results
{
    public class OperactionResult
    {
        public bool Success { get; set; } = true; // Por defecto, el resultado es exitoso.
        public string Message { get; set; } = "Operation completed successfully."; // Mensaje predeterminado.
    }
}

