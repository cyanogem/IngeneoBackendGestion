using Base.Abstraction.DTO.Authentication;
using Base.Entity.Dominio.Base;
using Base.Repository.Dominio;
using Base.Entity.Dominio;
using BaseAPI.Abstraction.DTO;
using BaseAPI.BAL;
using BaseAPI.BAL.Mesagges;
using BaseAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Base.BAL.Dominio
{
    public class AuthenticationBAL<T> : ABussinesBase<T> where T : Usuario
    {
        AuthenticationRepository<T> AuthenticationRepository;
        TextFunctions textFunctions;
        private readonly string? secretKey;
        public AuthenticationBAL(ILogger<AuthenticationBAL<T>> _logger, ResponseRepository<Response> _repmensajesrta, AuthenticationRepository<T> _contractRepo, IConfiguration config)
        {
            this.repositorioMensajesRta = _repmensajesrta;
            this.logger = _logger;
            this.AuthenticationRepository = _contractRepo;
            this.textFunctions = new TextFunctions();
            this.secretKey = config.GetSection("JWTKey").ToString();
        }


        public ResponseServicesDTO login(LoginDTO loginDTO)
        {
            
            UsuarioDTO usuarioDTO = AuthenticationRepository.getUsuario(loginDTO.usuario);

            if (usuarioDTO == null)
            {
                ResponseServicesDTO response = createResponse(
                     "Datos incorrectos",
                     false);
                return response;
            }
            else
            {
                var contraseñalogin = textFunctions.Encriptar(loginDTO.contraseña);

                if (contraseñalogin != usuarioDTO.Contraseña)
                {
                    ResponseServicesDTO response = createResponse(
                         "Contraseña Incorrecta",
                         false);
                    return response;
                }
                else
                {

                    var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                    var claims = new ClaimsIdentity();
                    claims.AddClaim(new Claim("Usuario", usuarioDTO.Usuario));
                    claims.AddClaim(new Claim("IdUsuario", usuarioDTO.usuarioId.ToString()));
                    claims.AddClaim(new Claim("PersonaId", usuarioDTO.PersonaId.ToString()));

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddMinutes(10),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                    string tokencreado = tokenHandler.WriteToken(tokenConfig);
                    ResponseServicesDTO response = createResponse(
                             tokencreado,
                             true);
                    return response;
                }
            }
            

        }

        override public ResponseServicesDTO GetById(int id, int language)
        {
            Object o = AuthenticationRepository.GetById(id);
            ResponseServicesDTO response = createResponse(
                o,
                true);
            return response;
        }

        override public ResponseServicesDTO GetAllByPage(int _page, int _countByPage, int language)
        {
            IList<T> o = AuthenticationRepository.GetAllByPage(_page, _countByPage);
            ResponseServicesDTO response = createResponse(
                o,
                true);
            logger.LogInformation("Retornando los registros del cliente");
            return response;
        }

        override public ResponseServicesDTO GetAll(int language)
        {
            Object o = AuthenticationRepository.GetAll();
            ResponseServicesDTO response = createResponse(
                o,
                true);
            logger.LogInformation("Retornando los registros del cliente");
            return response;
        }
        override public ResponseServicesDTO Save(T entity, int language)
        {
            Object o = AuthenticationRepository.Save(entity);
            ResponseServicesDTO response = createResponse(
                o,
                true);
            return response;
        }


        override public ResponseServicesDTO Update(T entity, int language)
        {
            Object o = AuthenticationRepository.Update(entity);
            ResponseServicesDTO response = createResponse(
                o,
                true);
            return response;
        }

        override public ResponseServicesDTO DeleteById(int id, int language)
        {
            AuthenticationRepository.DeleteById(id);
            ResponseServicesDTO response = createResponse(
                null,
                true);
            return response;
        }

    }
}
