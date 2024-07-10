using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Abstraction.DTO.Guia
{
    public class GuiaDTO
    {
        public int GuiaId { get; set; }
        public int ClienteId { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int BodegaId { get; set; }
        public string Bodega { get; set; }
        public int TipoGuiaId { get; set; }
        public string TipoGuia { get; set; }
        public string Consecutivo { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public string? NumeroGuia { get; set; }
    }
}
