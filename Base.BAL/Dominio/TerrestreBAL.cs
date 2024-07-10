using Base.Entity.Dominio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Base.Repository.Dominio;
using Base.Abstraction.DTO.Guia;
using BaseAPI.BAL;
using BaseAPI.Abstraction.DTO;

namespace Base.BAL.Dominio
{
    public class TerrestreBAL<T> : ABussinesBase<T> where T : Guium
    {
        TerrestreRepository<T> terrestreRepository;
        private readonly IConfiguration _configuration;
        public TerrestreBAL(ILogger<TerrestreBAL<T>> _logger,
            TerrestreRepository<T> _repositorio,
            IConfiguration configuration)
        {
            this.terrestreRepository = _repositorio;
            this.logger = _logger;
            this._configuration = configuration;
        }

        #region ReportePlanEntrega

        public ResponseServicesDTO ReportePlanEntrega()
        {
            List<ReportePlanEntregaDTO> reportePlanEntregas = terrestreRepository.ReportePlanEntrega();
            if (reportePlanEntregas != null)
            {
                ResponseServicesDTO response = createResponse(
               reportePlanEntregas,
               true);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false);
                return response;
            }
        }

        #endregion

        #region CRUD Guia
        public ResponseServicesDTO ListGuia()
        {
            List<GuiaDTO> guiaDTOs = terrestreRepository.ListGuia();
            if (guiaDTOs != null)
            {
                ResponseServicesDTO response = createResponse(
               guiaDTOs,
               true);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false);
                return response;
            }
        }
        public ResponseServicesDTO SaveGuia(GuiaDTO guiaDTO)
        {

            GuiaDTO guiaDTO1 = terrestreRepository.SaveGuia(guiaDTO);

            if (guiaDTO1 != null)
            {
                ResponseServicesDTO response = createResponse(
               guiaDTO1,
               true);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false);
                return response;
            }

        }
        public ResponseServicesDTO GetGuia(int GuiaId)
        {
            GuiaDTO guiaDTO = terrestreRepository.GetGuiaBy(GuiaId);
            if (guiaDTO != null)
            {
                ResponseServicesDTO response = createResponse(
               guiaDTO,
               true);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false);
                return response;
            }
        }

        #endregion

        #region CRUD GuiaProducto
        public ResponseServicesDTO SaveGuiaProducto(GuiaProductoDTO guiaProductoDTO)
        {
            GuiaProductoDTO guiaProductos = terrestreRepository.SaveGuiaProducto(guiaProductoDTO);
            if (guiaProductos != null)
            {
                ResponseServicesDTO response = createResponse(
               guiaProductos,
               true);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false);
                return response;
            }
        }
        public ResponseServicesDTO ListGuiaProducto(int GuiaId)
        {
            List<GuiaProductoDTO> guiaProductos = terrestreRepository.ListGuiaProducto(GuiaId);
            if (guiaProductos != null)
            {
                ResponseServicesDTO response = createResponse(
               guiaProductos,
               true);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false);
                return response;
            }
        }
        public ResponseServicesDTO GetGuiaProducto(int GuiaProductoId)
        {
            GuiaProductoDTO guiaProductoDTO = terrestreRepository.GetGuiaProductoBy(GuiaProductoId);
            if (guiaProductoDTO != null)
            {
                ResponseServicesDTO response = createResponse(
               guiaProductoDTO,
               true);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false);
                return response;
            }
        }

        #endregion

        #region CRUD Cliente
        public ResponseServicesDTO ListCliente()
        {
            List<ClienteDTO> clienteDTOs = terrestreRepository.ListCliente();
            if (clienteDTOs != null)
            {
                ResponseServicesDTO response = createResponse(
               clienteDTOs,
               true);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false);
                return response;
            }
        }
        public ResponseServicesDTO SaveCliente(ClienteDTO clienteDTO)
        {

            ClienteDTO cliente = terrestreRepository.SaveCliente(clienteDTO);

            if (cliente != null)
            {
                ResponseServicesDTO response = createResponse(
               cliente,
               true);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false);
                return response;
            }

        }
        public ResponseServicesDTO GetCliente(int ClienteId)
        {
            ClienteDTO cliente = terrestreRepository.GetClienteBy(ClienteId);
            if (cliente != null)
            {
                ResponseServicesDTO response = createResponse(
               cliente,
               true);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false);
                return response;
            }
        }

        #endregion

        #region CRUD Bodega
        public ResponseServicesDTO ListBodega()
        {
            List<BodegaDTO> bodegas = terrestreRepository.ListBodega();
            if (bodegas != null)
            {
                ResponseServicesDTO response = createResponse(
               bodegas,
               true);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false);
                return response;
            }
        }
        public ResponseServicesDTO SaveBodega(BodegaDTO bodegaDTO)
        {

            BodegaDTO bodega = terrestreRepository.SaveBodega(bodegaDTO);

            if (bodega != null)
            {
                ResponseServicesDTO response = createResponse(
               bodega,
               true);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false);
                return response;
            }

        }
        public ResponseServicesDTO GetBodega(int BodegaId)
        {
            BodegaDTO bodega = terrestreRepository.GetBodegaBy(BodegaId);
            if (bodega != null)
            {
                ResponseServicesDTO response = createResponse(
               bodega,
               true);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false);
                return response;
            }
        }

        #endregion

        #region CRUD Producto
        public ResponseServicesDTO ListProducto()
        {
            List<ProductoDTO> productos = terrestreRepository.ListProducto();
            if (productos != null)
            {
                ResponseServicesDTO response = createResponse(
               productos,
               true);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false);
                return response;
            }
        }
        public ResponseServicesDTO SaveProducto(ProductoDTO productoDTO)
        {

            ProductoDTO producto = terrestreRepository.SaveProducto(productoDTO);

            if (producto != null)
            {
                ResponseServicesDTO response = createResponse(
               producto,
               true);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false);
                return response;
            }

        }
        public ResponseServicesDTO GetProducto(int ProductoId)
        {
            ProductoDTO productoDTO = terrestreRepository.GetProductoBy(ProductoId);
            if (productoDTO != null)
            {
                ResponseServicesDTO response = createResponse(
               productoDTO,
               true);
                return response;

            }
            else
            {
                ResponseServicesDTO response = createResponse(
                  null,
                  false);
                return response;
            }
        }

        public override ResponseServicesDTO DeleteById(int id, int language)
        {
            throw new NotImplementedException();
        }

        public override ResponseServicesDTO GetAll(int language)
        {
            throw new NotImplementedException();
        }

        public override ResponseServicesDTO GetAllByPage(int _page, int _countByPage, int language)
        {
            throw new NotImplementedException();
        }

        public override ResponseServicesDTO GetById(int id, int language)
        {
            throw new NotImplementedException();
        }

        public override ResponseServicesDTO Save(T entity, int language)
        {
            throw new NotImplementedException();
        }

        public override ResponseServicesDTO Update(T entity, int language)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
