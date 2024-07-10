using Base.Repository.Dominio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Base.Abstraction.DTO.Guia;
using BaseAPI.Abstraction.DTO;
using Base.Entity.Dominio;
using BaseAPI.BAL;

namespace Base.BAL.Dominio
{
    public class MaritimaBAL<T> : ABussinesBase<T> where T : Guium
    {
        MaritimaRepository<T> maritimaRepository;
        private readonly IConfiguration _configuration;
        public MaritimaBAL(ILogger<MaritimaBAL<T>> _logger,
            MaritimaRepository<T> _repositorio,
            IConfiguration configuration)
        {
            this.maritimaRepository = _repositorio;
            this.logger = _logger;
            this._configuration = configuration;
        }

        #region ReportePlanEntrega

        public ResponseServicesDTO ReportePlanEntrega()
        {
            List<ReportePlanEntregaDTO> reportePlanEntregas = maritimaRepository.ReportePlanEntrega();
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
        public ResponseServicesDTO ReportePlanEntregaAll()
        {
            List<ReportePlanEntregaDTO> reportePlanEntregas = maritimaRepository.ReportePlanEntregaAll();
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
            List<GuiaDTO> guiaDTOs = maritimaRepository.ListGuia();
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

            GuiaDTO guiaDTO1 = maritimaRepository.SaveGuia(guiaDTO);

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
            GuiaDTO guiaDTO = maritimaRepository.GetGuiaBy(GuiaId);
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
            GuiaProductoDTO guiaProductos = maritimaRepository.SaveGuiaProducto(guiaProductoDTO);
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
            GuiaProductoDTO guiaProductoDTO = maritimaRepository.GetGuiaPrpductoBy(GuiaProductoId);
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
        public ResponseServicesDTO ListGuiaProducto(int GuiaId)
        {
            List<GuiaProductoDTO> guiaProductos = maritimaRepository.ListGuiaProducto(GuiaId);
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

        #region transversal
        public ResponseServicesDTO ListCliente()
        {
            List<ClienteDTO> guiaProductos = maritimaRepository.ListCliente();
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
        public ResponseServicesDTO ListBodega()
        {
            List<BodegaDTO> guiaProductos = maritimaRepository.ListBodega();
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
        public ResponseServicesDTO ListTipoGuia()
        {
            List<TipoGuiaDTO> guiaProductos = maritimaRepository.ListTipoGuia();
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
        #endregion

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
