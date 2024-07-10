using BaseAPI.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Entity.Dominio.Base
{
    public partial class Response : IEntity
    {
        public int IdResponse { get; set; }
        public int ResponseCode { get; set; }
        public int IdIdioma { get; set; }
        public string ResponseMessage { get; set; } = null!;
        public int Status { get; set; }
    }
}
