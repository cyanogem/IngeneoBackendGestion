using BaseAPI.Abstraction;
using System;
using System.Collections.Generic;

namespace Base.Entity.Dominio
{
    public partial class Usuario: IEntity
    {
        public Usuario()
        {
            UsuarioxRoles = new HashSet<UsuarioxRole>();
        }

        public int UsuarioId { get; set; }
        public string Password { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Bloqueado { get; set; }
        public int IntentosFallidos { get; set; }
        public int PersonaId { get; set; }

        public virtual Persona Persona { get; set; } = null!;
        public virtual ICollection<UsuarioxRole> UsuarioxRoles { get; set; }
    }
}
