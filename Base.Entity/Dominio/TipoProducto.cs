using BaseAPI.Abstraction;
using System;
using System.Collections.Generic;

namespace Base.Entity.Dominio
{
    public partial class TipoProducto : IEntity
    {
        public TipoProducto()
        {
            Productos = new HashSet<Producto>();
        }

        public int TipoProductoId { get; set; }
        public string DescripcionTipoProducto { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
