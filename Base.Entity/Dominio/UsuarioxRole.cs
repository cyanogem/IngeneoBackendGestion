using BaseAPI.Abstraction;
using System;
using System.Collections.Generic;

namespace Base.Entity.Dominio
{
    public partial class UsuarioxRole : IEntity
    {
        public int UsuarioIdxRolesId { get; set; }
        public int UsuarioId { get; set; }
        public int RolId { get; set; }

        public virtual Role Rol { get; set; } = null!;
        public virtual Usuario Usuario { get; set; } = null!;
    }
}
