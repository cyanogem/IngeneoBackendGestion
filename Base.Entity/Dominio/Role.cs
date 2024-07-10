using BaseAPI.Abstraction;
using System;
using System.Collections.Generic;

namespace Base.Entity.Dominio
{
    public partial class Role : IEntity
    {
        public Role()
        {
            UsuarioxRoles = new HashSet<UsuarioxRole>();
        }

        public int RolId { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<UsuarioxRole> UsuarioxRoles { get; set; }
    }
}
