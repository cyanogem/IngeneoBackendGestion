using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Abstraction.DTO
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public DateTime FechaExpiracionToken { get; set; }
    }
}
