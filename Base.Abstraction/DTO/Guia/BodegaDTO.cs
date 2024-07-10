using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Abstraction.DTO.Guia
{
    public class BodegaDTO
    {
        public int BodegaId { get; set; }
        public string DescripcionBodega { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
