using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseAPI.Abstraction.DTO
{
    public class ErrorDetails
    {
        public int ErrorStatusCode { get; set; }
        public string ErroMessage { get; set; }
        public string? ErrorStackTrace { get; set; }


        public ErrorDetails()
        {
            this.ErrorStatusCode = 0;
            this.ErroMessage = string.Empty;
            this.ErrorStackTrace = string.Empty;
        }
    }
}
