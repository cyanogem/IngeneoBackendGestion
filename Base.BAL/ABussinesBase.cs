using BaseAPI.Abstraction;
using BaseAPI.Abstraction.DTO;
using Microsoft.Extensions.Logging;
using Base.Entity.Dominio.Base;
using Base.Repository.Dominio;

namespace BaseAPI.BAL
{

    public interface IABussinesBase<T> : ICRUDBAL<T>
    {

    }

    public abstract class ABussinesBase<T> : IABussinesBase<T> where T : IEntity
    {
        public ILogger? logger;
        public ResponseRepository<Response>? repositorioMensajesRta;
        

        public abstract ResponseServicesDTO DeleteById(int id, int language);
        public abstract ResponseServicesDTO GetAll(int language);
        public abstract ResponseServicesDTO GetAllByPage(int _page, int _countByPage, int language);
        public abstract ResponseServicesDTO GetById(int id, int language);
        public abstract ResponseServicesDTO Save(T entity, int language);
        public abstract ResponseServicesDTO Update(T entity, int language);


        public ResponseServicesDTO createResponse(Object? objectResponse, bool success)
        {
            return new ResponseServicesDTO()
            {
                ObjectResponse = objectResponse,
                Success = success
            };
        }

        public string? getResponseMessage(int code, int language)
        {
            string mesagge = "";
            Response respuesta = this.repositorioMensajesRta.GetByCodigoRespuesta(code, language);
            if (respuesta != null)
                mesagge = respuesta.ResponseMessage;
            return mesagge;
        }
        
    }
}
