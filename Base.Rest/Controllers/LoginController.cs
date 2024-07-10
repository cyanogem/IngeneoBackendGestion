using Base.Abstraction.DTO.Authentication;
using Base.BAL.Dominio;
using Base.Entity.Dominio;
using BaseAPI.Abstraction.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Base.Rest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILogger _logger;
        AuthenticationBAL<Usuario> _logicaBAL;
        public LoginController(ILogger<LoginController> _logger, AuthenticationBAL<Usuario> _logicaBAL)
        {
            this._logicaBAL = _logicaBAL;
            this._logger = _logger;
        }
        [HttpPost]
        public ActionResult<ResponseServicesDTO> Login(LoginDTO loginDTO)
        {
            return (this._logicaBAL.login(loginDTO));//
        }

    }
}
