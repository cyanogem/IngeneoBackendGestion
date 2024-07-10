using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Abstraction.DTO.Guia
{
    public class GuiaProductoDTO
    {
        public int GuiaProductoId { get; set; }
        public int GuiaId { get; set; }
        public int ProductoId { get; set; }
        public int CantidadProducto { get; set; }
        public string DescripcionGuiaProducto { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public decimal PrecioEnvio { get; set; }

    }
}
