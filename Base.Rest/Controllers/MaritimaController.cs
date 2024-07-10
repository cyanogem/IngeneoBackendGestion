using Microsoft.AspNetCore.Mvc;
using Base.Entity.Dominio;
using BaseAPI.Abstraction.DTO;
using Base.BAL.Dominio;
using Base.Abstraction.DTO.Guia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Base.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaritimaController : Controller
    {
        ILogger _logger;
        MaritimaBAL<Guium> _logicaBAL;

        public MaritimaController(ILogger<Guium> _logger, MaritimaBAL<Guium> _logicaBAL)
        {
            this._logicaBAL = _logicaBAL;
            this._logger = _logger;
        }

        #region ReportePlanEntrega
        [HttpGet]
        public ActionResult<ResponseServicesDTO> ListReporteplanEntrega()
        {
            return this._logicaBAL.ReportePlanEntrega();
        }
        [HttpGet]
        public ActionResult<ResponseServicesDTO> ListReporteplanEntregaAll()
        {
            return this._logicaBAL.ReportePlanEntregaAll();
        }
        #endregion
        #region CRUD Guia
        [HttpGet]
        public ActionResult<ResponseServicesDTO> ListGuia()
        {
            return this._logicaBAL.ListGuia();
        }
        [HttpGet]
        public ActionResult<ResponseServicesDTO> GetGuiaById(int GuiaId)
        {
            return this._logicaBAL.GetGuia(GuiaId);

        }
        [HttpPost]
        public ActionResult<ResponseServicesDTO> SaveGuia(GuiaDTO guiaDTO)
        {
            return this._logicaBAL.SaveGuia(guiaDTO);

        }
        #endregion

        #region CRUD GuiaProducto
        [HttpGet]
        public ActionResult<ResponseServicesDTO> ListGuiaProducto(int GuiaId)
        {
            return this._logicaBAL.ListGuiaProducto(GuiaId);
        }
        [HttpGet]
        public ActionResult<ResponseServicesDTO> GetGuiaProductoById(int GuiaId)
        {
            return this._logicaBAL.GetGuia(GuiaId);

        }
        [HttpPost]
        public ActionResult<ResponseServicesDTO> SaveGuiaProducto(GuiaProductoDTO guiaProductoDTO)
        {
            return this._logicaBAL.SaveGuiaProducto(guiaProductoDTO);

        }
        #endregion

        #region transversal 
        [HttpGet]
        public ActionResult<ResponseServicesDTO> ListCliente()
        {
            return this._logicaBAL.ListCliente();
        }
        [HttpGet]
        public ActionResult<ResponseServicesDTO> ListBodega()
        {
            return this._logicaBAL.ListBodega();
        }
        [HttpGet]
        public ActionResult<ResponseServicesDTO> ListTipoGuia()
        {
            return this._logicaBAL.ListTipoGuia();
        }
        #endregion

    }
}
