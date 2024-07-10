using BaseAPI.Abstraction;
using System;
using System.Collections.Generic;

namespace Base.Entity.Dominio
{
    public partial class Guium : IEntity
    {
        public Guium()
        {
            GuiaProductos = new HashSet<GuiaProducto>();
        }

        public int GuiaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int BodegaId { get; set; }
        public int TipoGuiaId { get; set; }
        public string Consecutivo { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public string? NumeroGuia { get; set; }

        public virtual Bodega Bodega { get; set; } = null!;
        public virtual Cliente Cliente { get; set; } = null!;
        public virtual TipoGuium TipoGuia { get; set; } = null!;
        public virtual ICollection<GuiaProducto> GuiaProductos { get; set; }
    }
}
