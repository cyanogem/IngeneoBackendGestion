using BaseAPI.Abstraction;
using System;
using System.Collections.Generic;

namespace Base.Entity.Dominio
{
    public partial class Respuestum :IEntity
    {
        public int IdRespuesta { get; set; }
        public int CodigoRespuesta { get; set; }
        public int IdIdioma { get; set; }
        public string MensajeRespuesta { get; set; } = null!;
        public int Estado { get; set; }
    }
}
