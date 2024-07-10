using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Abstraction.DTO.Guia
{
    public class ReportePlanEntregaDTO
    {
        public string TipoProducto { get; set; }
        public int CantidadProducto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Bodega { get; set; }
        public decimal PrecioEnvio { get; set; }
        public string NumeroFlota { get; set; }
        public string NumeroGuia { get; set; }
        public string? TipoGuia { get; set; }
    }
}
