using BaseAPI.Abstraction;
using System;
using System.Collections.Generic;

namespace Base.Entity.Dominio
{
    public partial class GuiaProducto : IEntity
    {
        public int GuiaProductoId { get; set; }
        public int GuiaId { get; set; }
        public int ProductoId { get; set; }
        public int CantidadProducto { get; set; }
        public string DescripcionGuiaProducto { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public decimal PrecioEnvio { get; set; }

        public virtual Guium Guia { get; set; } = null!;
        public virtual Producto Producto { get; set; } = null!;
    }
}
