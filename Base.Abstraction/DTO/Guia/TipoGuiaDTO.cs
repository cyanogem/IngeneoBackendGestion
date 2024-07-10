using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Abstraction.DTO.Guia
{
    public class TipoGuiaDTO
    {
        public int TipoGuiaId { get; set; }
        public string DescripcionTipoGuia { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
