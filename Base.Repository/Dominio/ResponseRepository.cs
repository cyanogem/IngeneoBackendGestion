using Microsoft.Extensions.Logging;
using BaseAPI.Abstraction.DBContext;
using BaseAPI.DataAccess;
using BaseAPI.Repository;
using Base.Entity.Dominio.Base;

namespace Base.Repository.Dominio
{
    public class ResponseRepository<T> : ARepositoryBase<T> where T : Response
    {
        ILogger logger;
        IDBContext<T> dbctx;
        APIDBContext db;
        public ResponseRepository(ILogger<ResponseRepository<T>> _logger, IDBContext<T> _ctx, APIDBContext _db) : base(_logger, _ctx, _db)
        {
            this.dbctx = _ctx;
            this.logger = _logger;
            this.db = _db;
        }

        public T Save(T entity)
        {
            return this.dbctx.Save(entity);
        }
        public Response? GetByCodigoRespuesta(int code, int language)
        {
            return this.dbctx.GetAll().Where(x => x.ResponseCode.Equals(code)).Where(x => x.IdIdioma.Equals(language)).Take(1).FirstOrDefault();
        }
    }
}
