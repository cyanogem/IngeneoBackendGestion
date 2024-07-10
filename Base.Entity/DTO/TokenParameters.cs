using BaseAPI.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseAPI.Entity.DTO
{
    public class TokenParameters : ITokenParameters
    {
        public string UserName { get; set ; }
        public string PasswordHash { get; set; }
        public string Id { get; set; }

    }
}
