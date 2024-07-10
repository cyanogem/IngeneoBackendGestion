using BaseAPI.Abstraction;
using System;
using System.Collections.Generic;

namespace Base.Entity.Dominio
{
    public partial class Persona : IEntity
    {
        public Persona()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int PersonaId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int Telefono { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
