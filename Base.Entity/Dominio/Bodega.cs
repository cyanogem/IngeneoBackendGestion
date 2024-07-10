using BaseAPI.Abstraction;
using System;
using System.Collections.Generic;

namespace Base.Entity.Dominio
{
    public partial class Bodega : IEntity
    {
        public Bodega()
        {
            Guia = new HashSet<Guium>();
        }

        public int BodegaId { get; set; }
        public string DescripcionBodega { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<Guium> Guia { get; set; }
    }
}
