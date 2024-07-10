using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Abstraction.DTO.Guia
{
    public class ProductoDTO
    {
        public int ProductoId { get; set; }
        public int TipoProductoId { get; set; }
        public string TipoProducto { get; set; }
        public string DescripcionProducto { get; set; } = null!;
        public bool Activo { get; set; }
        public decimal Precio { get; set; }
    }
}
