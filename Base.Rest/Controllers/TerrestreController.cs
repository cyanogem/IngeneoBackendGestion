using Base.Abstraction.DTO.Guia;
using Base.BAL.Dominio;
using Base.Entity.Dominio;
using BaseAPI.Abstraction.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Base.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TerrestreController : Controller
    {
        ILogger _logger;
        TerrestreBAL<Guium> _logicaBAL;

        public TerrestreController(ILogger<Guium> _logger, TerrestreBAL<Guium> _logicaBAL)
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
        //[HttpPost]
        //public ActionResult<ResponseServicesDTO> DeleteGuia(int eliminar)
        //{
        //    return this._logicaBAL.DeleteById(eliminar);

        //}
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

        #region CRUD Cliente
        [HttpGet]
        public ActionResult<ResponseServicesDTO> ListCliente()
        {
            return this._logicaBAL.ListCliente();
        }
        [HttpGet]
        public ActionResult<ResponseServicesDTO> GetClienteById(int GuiaId)
        {
            return this._logicaBAL.GetCliente(GuiaId);

        }
        [HttpPost]
        public ActionResult<ResponseServicesDTO> SaveCliente(ClienteDTO clienteDTO)
        {
            return this._logicaBAL.SaveCliente(clienteDTO);

        }
        //[HttpPost]
        //public ActionResult<ResponseServicesDTO> DeleteGuia(int eliminar)
        //{
        //    return this._logicaBAL.DeleteById(eliminar);

        //}
        #endregion

        #region CRUD Bodega
        [HttpGet]
        public ActionResult<ResponseServicesDTO> ListBodega()
        {
            return this._logicaBAL.ListBodega();
        }
        [HttpGet]
        public ActionResult<ResponseServicesDTO> GetBodegaById(int BodegaId)
        {
            return this._logicaBAL.GetBodega(BodegaId);

        }
        [HttpPost]
        public ActionResult<ResponseServicesDTO> SaveBodega(BodegaDTO bodegaDTO)
        {
            return this._logicaBAL.SaveBodega(bodegaDTO);

        }
        //[HttpPost]
        //public ActionResult<ResponseServicesDTO> DeleteGuia(int eliminar)
        //{
        //    return this._logicaBAL.DeleteById(eliminar);

        //}
        #endregion

        #region CRUD Producto
        [HttpGet]
        public ActionResult<ResponseServicesDTO> ListProducto()
        {
            return this._logicaBAL.ListProducto();
        }
        [HttpGet]
        public ActionResult<ResponseServicesDTO> GetProductoById(int ProductoId)
        {
            return this._logicaBAL.GetProducto(ProductoId);

        }
        [HttpPost]
        public ActionResult<ResponseServicesDTO> SaveProducto(ProductoDTO productoDTO)
        {
            return this._logicaBAL.SaveProducto(productoDTO);

        }
        //[HttpPost]
        //public ActionResult<ResponseServicesDTO> DeleteGuia(int eliminar)
        //{
        //    return this._logicaBAL.DeleteById(eliminar);

        //}
        #endregion
    }
}
