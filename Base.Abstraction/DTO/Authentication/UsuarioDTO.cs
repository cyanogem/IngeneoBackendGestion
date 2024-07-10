using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Abstraction.DTO.Authentication
{
    public class UsuarioDTO
    {
        public int usuarioId { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public bool Activo { get; set; }
        public bool bloqueado { get; set; }
        public int intentosFallido { get; set; }
        public int PersonaId { get; set; }
    }
}
