using BaseAPI.Abstraction.DTO;
using BaseAPI.BAL.Mesagges;
using BaseAPI.Entity.DTO;
using BaseAPI.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseAPI.BAL
{
    public class AuthBAL
    {
        ILogger logger;
        ITokenHandlerService _tokenService;
        public AuthBAL(ILogger<AuthBAL> logger, ITokenHandlerService tservice)
        {
            this.logger = logger;
            _tokenService = tservice;
        }

        


        public ResponseServicesDTO createResponse(Object? objectResponse, bool success)
        {
            return new ResponseServicesDTO()
            {
                ObjectResponse = objectResponse,
                Success = success
            };
        }


        public string? getResponseMessage()
        {
            string mesagge = "Satisfactorio";
            return mesagge;
        }
    }
}
