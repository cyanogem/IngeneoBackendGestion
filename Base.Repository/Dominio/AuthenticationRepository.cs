using Base.Abstraction.DTO.Authentication;
using Base.Entity.Dominio;
using BaseAPI.Abstraction.DBContext;
using BaseAPI.DataAccess;
using BaseAPI.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Repository.Dominio
{

    public class AuthenticationRepository<T> : ARepositoryBase<T> where T : Usuario
    {
        ILogger logger;
        IDBContext<T> dbctx;
        APIDBContext db;
        public AuthenticationRepository(ILogger<AuthenticationRepository<T>> _logger, IDBContext<T> _ctx, APIDBContext _db) : base(_logger, _ctx, _db)
        {
            this.dbctx = _ctx;
            this.logger = _logger;
            this.db = _db;
        }

        public T Save(T entity)
        {
            return this.dbctx.Save(entity);
        }

        public UsuarioDTO getUsuario(string? usuario)
        {
            UsuarioDTO? usuarioModel = (from ct in db.Usuarios        
                                                where ct.Nombre == usuario

                                                select new UsuarioDTO()
                                                {
                                                    usuarioId = ct.UsuarioId,
                                                    Usuario = ct.Nombre,
                                                    Contraseña = ct.Password,
                                                    bloqueado = ct.Bloqueado,
                                                    intentosFallido = ct.IntentosFallidos,
                                                    Activo = ct.Activo,
                                                    PersonaId = ct.PersonaId

                                                }).FirstOrDefault();
            return usuarioModel;
        }

    }
}
