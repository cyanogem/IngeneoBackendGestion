using BaseAPI.Abstraction;
using System;
using System.Collections.Generic;

namespace Base.Entity.Dominio
{
    public partial class TipoGuium : IEntity
    {
        public TipoGuium()
        {
            Guia = new HashSet<Guium>();
        }

        public int TipoGuiaId { get; set; }
        public string DescripcionTipoGuia { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<Guium> Guia { get; set; }
    }
}
