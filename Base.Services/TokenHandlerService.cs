using BaseAPI.Abstraction;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BaseAPI.Services { 

    public interface ITokenHandlerService
    {
        string GenerateJWTToken(ITokenParameters parameters);
    }


    public class TokenHandlerService : ITokenHandlerService
    {
        private ILogger _logger;
        private readonly JWTConfig _jwtConfig;

        public TokenHandlerService(ILogger<TokenHandlerService> _logger, IOptionsMonitor<JWTConfig> optionsMonitor)
        {
            this._logger = _logger;
            this._jwtConfig = optionsMonitor.CurrentValue;
        }

        public string GenerateJWTToken(ITokenParameters parameters)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity( new[]
                {
                    new Claim( "Id", parameters.Id),
                    new Claim( JwtRegisteredClaimNames.Sub , parameters.UserName),
                    new Claim( JwtRegisteredClaimNames.Email, parameters.UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials( new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature )
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            _logger.LogInformation("En Service mensaje!!!");
            return jwtToken;
        }

    }
}
