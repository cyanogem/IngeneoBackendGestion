using BaseAPI.Abstraction;
using System;
using System.Collections.Generic;

namespace Base.Entity.Dominio
{
    public partial class Producto : IEntity
    {
        public Producto()
        {
            GuiaProductos = new HashSet<GuiaProducto>();
        }

        public int ProductoId { get; set; }
        public int TipoProductoId { get; set; }
        public string DescripcionProducto { get; set; } = null!;
        public bool Activo { get; set; }
        public decimal Precio { get; set; }

        public virtual TipoProducto TipoProducto { get; set; } = null!;
        public virtual ICollection<GuiaProducto> GuiaProductos { get; set; }
    }
}
