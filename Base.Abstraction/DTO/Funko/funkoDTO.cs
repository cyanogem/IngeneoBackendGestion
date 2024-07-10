using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Abstraction.DTO.Funko
{
    public class funkoDTO
    {
        public int IdFunko { get; set; }
        public string Descripcion { get; set; } = null!;
        public int Codigo { get; set; }
        public int Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdTipoFunko { get; set; }
        public string TipoFunko { get; set; }
        public string? Exclusivo { get; set; }
    }
}
