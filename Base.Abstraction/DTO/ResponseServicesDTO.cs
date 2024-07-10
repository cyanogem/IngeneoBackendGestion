using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseAPI.Abstraction.DTO
{
    public class ResponseServicesDTO
    {
        public Object? ObjectResponse { get; set; }
        public bool Success { get; set; }
        public ErrorDetails ErrorDetails { get; set; }

        public ResponseServicesDTO()
        {
            this.ObjectResponse = null;
            this.Success = false;
            this.ErrorDetails = new ErrorDetails();
        }


    }
}
