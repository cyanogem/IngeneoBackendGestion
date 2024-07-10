using Base.Abstraction.DTO.Guia;
using Base.Entity.Dominio;
using BaseAPI.Abstraction.DBContext;
using BaseAPI.DataAccess;
using BaseAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Base.Repository.Dominio
{
    public class MaritimaRepository<T> : ARepositoryBase<T> where T : Guium
    {
        ILogger logger;
        IDBContext<T> dbctx;
        APIDBContext db;
        public MaritimaRepository(ILogger<MaritimaRepository<T>> _logger, IDBContext<T> _ctx, APIDBContext _db) : base(_logger, _ctx, _db)
        {
            this.dbctx = _ctx; 
            this.logger = _logger;
            this.db = _db;
        }

        public T Save(T entity)
        {
            return this.dbctx.Save(entity);
        }

        #region ReportePlanEntrega
        public List<ReportePlanEntregaDTO> ReportePlanEntrega()
        {
            List<ReportePlanEntregaDTO> reportePlanEntregas = (from g in db.GuiaProductos
                                      where g.Guia.TipoGuiaId == 1
                                      select new ReportePlanEntregaDTO()
                                      {
                                          TipoProducto = g.Producto.DescripcionProducto,
                                          CantidadProducto = g.CantidadProducto,
                                          FechaRegistro = g.FechaRegistro,
                                          FechaEntrega = g.FechaRegistro,
                                          Bodega = g.Guia.Bodega.DescripcionBodega,
                                          PrecioEnvio = g.PrecioEnvio,
                                          NumeroFlota = g.Guia.Consecutivo,
                                          NumeroGuia = g.Guia.NumeroGuia,
                                      }).ToList();
            return reportePlanEntregas;
        }
        public List<ReportePlanEntregaDTO> ReportePlanEntregaAll()
        {
            List<ReportePlanEntregaDTO> reportePlanEntregas = (from g in db.GuiaProductos
                                                               select new ReportePlanEntregaDTO()
                                                               {
                                                                   TipoProducto = g.Producto.DescripcionProducto,
                                                                   CantidadProducto = g.CantidadProducto,
                                                                   FechaRegistro = g.FechaRegistro,
                                                                   FechaEntrega = g.FechaRegistro,
                                                                   Bodega = g.Guia.Bodega.DescripcionBodega,
                                                                   PrecioEnvio = g.PrecioEnvio,
                                                                   NumeroFlota = g.Guia.Consecutivo,
                                                                   NumeroGuia = g.Guia.NumeroGuia,
                                                                   TipoGuia = g.Guia.TipoGuia.DescripcionTipoGuia
                                                               }).ToList();
            return reportePlanEntregas;
        }
        #endregion

        #region Guia
        public GuiaDTO SaveGuia(GuiaDTO guiaDTO)
        {
            Guium guium;
            guium = new Guium();
            //Valido si el obejto viene para ser creado o editado 
            if (guiaDTO.GuiaId == 0)
            {
                guium.ClienteId = guiaDTO.ClienteId;
                guium.FechaEntrega = guiaDTO.FechaEntrega;
                guium.BodegaId = guiaDTO.BodegaId;
                guium.TipoGuiaId = guiaDTO.TipoGuiaId;
                if (validateConsecutivo(guiaDTO.TipoGuiaId, guiaDTO.Consecutivo))
                {
                    guium.Consecutivo = guiaDTO.Consecutivo;
                }
                else
                {
                    ///piendiente para ver que retorno
                }
                guium.FechaRegistro = DateTime.Now;
                guium.Consecutivo = guiaDTO.Consecutivo;
                guium.NumeroGuia = CreadorGuia();
                guium.FechaEntrega = DateTime.Now;

                db.Guia.Add(guium);

                db.SaveChanges();
            }
            else
            {
                Guium guium1 = db.Guia.Where(r => r.GuiaId == guiaDTO.GuiaId).FirstOrDefault();

                guium1.ClienteId = guiaDTO.ClienteId;
                guium1.FechaEntrega = guium1.FechaEntrega;
                guium1.BodegaId = guiaDTO.BodegaId;
                if (validateConsecutivo(guiaDTO.TipoGuiaId, guiaDTO.Consecutivo))
                {
                    guium1.Consecutivo = guiaDTO.Consecutivo;
                }
                else
                {
                    ///piendiente para ver que retorno
                }
                db.Entry(guium1).State = EntityState.Modified;
                db.SaveChanges();

            }
            return guiaDTO;
        }
        public List<GuiaDTO> ListGuia()
        {
            List<GuiaDTO> guiaDTOs = (from g in db.Guia
                                      where g.TipoGuiaId == 1
                                      select new GuiaDTO()
                                      {
                                          ClienteId = g.ClienteId,
                                          Cliente = g.Cliente.Nombre,
                                          FechaEntrega = g.FechaEntrega,
                                          BodegaId = g.BodegaId,
                                          TipoGuiaId = g.TipoGuiaId,
                                          Consecutivo = g.Consecutivo,
                                          NumeroGuia = g.NumeroGuia,
                                          Bodega = g.Bodega.DescripcionBodega,
                                          TipoGuia = g.TipoGuia.DescripcionTipoGuia,
                                          GuiaId = g.GuiaId

                                      }).ToList();
            return guiaDTOs;
        }
        public GuiaDTO GetGuiaBy(int GuiaId)
        {
            GuiaDTO? guiaDTO = (from g in db.Guia
                                where g.GuiaId == GuiaId
                                select new GuiaDTO()
                                {
                                    GuiaId = g.GuiaId,
                                    ClienteId = g.ClienteId,
                                    FechaEntrega = g.FechaEntrega,
                                    BodegaId = g.BodegaId,
                                    TipoGuiaId = g.TipoGuiaId,
                                    Consecutivo = g.Consecutivo,
                                    FechaRegistro = g.FechaRegistro,
                                    NumeroGuia = g.NumeroGuia

                                }).FirstOrDefault();
            return guiaDTO;
        }
        public int DeleteGuia(int eliminar)
        {
            Guium guium = db.Guia.Where(x => x.GuiaId == eliminar).FirstOrDefault();

            db.Guia.Remove(guium);
            db.SaveChanges();

            return eliminar;
        }
        #endregion

        #region Guia_Producto
        public GuiaProductoDTO SaveGuiaProducto(GuiaProductoDTO guiaProductoDTO)
        {
            GuiaProducto guiaProducto;
            guiaProducto = new GuiaProducto();
            //Valido si el obejto viene para ser creado o editado 
            if (guiaProductoDTO.GuiaProductoId == 0)
            {
                guiaProducto.ProductoId = guiaProductoDTO.ProductoId;
                guiaProducto.GuiaId = guiaProductoDTO.GuiaId;
                guiaProducto.CantidadProducto = guiaProductoDTO.CantidadProducto;
                guiaProducto.DescripcionGuiaProducto = guiaProductoDTO.DescripcionGuiaProducto;
                guiaProducto.FechaRegistro = guiaProductoDTO.FechaRegistro;

                if (guiaProductoDTO.CantidadProducto > 10)
                {
                    guiaProducto.PrecioEnvio = guiaProductoDTO.PrecioEnvio - (guiaProductoDTO.PrecioEnvio * (decimal)0.03);
                }
                else
                {
                    guiaProducto.PrecioEnvio = guiaProductoDTO.PrecioEnvio;
                }

                db.GuiaProductos.Add(guiaProducto);

                db.SaveChanges();
            }
            else
            {
                GuiaProducto guiaProducto1 = db.GuiaProductos.Where(r => r.GuiaProductoId == guiaProductoDTO.GuiaProductoId).FirstOrDefault();

                guiaProducto1.ProductoId = guiaProductoDTO.ProductoId;
                guiaProducto1.GuiaId = guiaProductoDTO.GuiaId;
                guiaProducto1.CantidadProducto = guiaProductoDTO.CantidadProducto;
                guiaProducto1.DescripcionGuiaProducto = guiaProductoDTO.DescripcionGuiaProducto;

                if (guiaProductoDTO.CantidadProducto > 10)
                {
                    guiaProducto.PrecioEnvio = guiaProductoDTO.PrecioEnvio - (guiaProductoDTO.PrecioEnvio * (decimal)0.5);
                }
                else
                {
                    guiaProducto.PrecioEnvio = guiaProductoDTO.PrecioEnvio;
                }

                db.Entry(guiaProducto1).State = EntityState.Modified;
                db.SaveChanges();

            }
            return guiaProductoDTO;
        }
        public GuiaProductoDTO GetGuiaPrpductoBy(int GuiaProductoId)
        {
            GuiaProductoDTO? guiaProductoDTO = (from g in db.GuiaProductos
                                                where g.GuiaProductoId == GuiaProductoId
                                                select new GuiaProductoDTO()
                                                {
                                                    GuiaProductoId = g.GuiaProductoId,
                                                    GuiaId = g.GuiaId,
                                                    ProductoId = g.ProductoId,
                                                    CantidadProducto = g.CantidadProducto,
                                                    DescripcionGuiaProducto = g.DescripcionGuiaProducto,
                                                    FechaRegistro = g.FechaRegistro,
                                                    PrecioEnvio = g.PrecioEnvio

                                                }).FirstOrDefault();
            return guiaProductoDTO;
        }
        public int DeleteGuiaProducto(int eliminar)
        {
            GuiaProducto guiaProducto = db.GuiaProductos.Where(x => x.GuiaProductoId == eliminar).FirstOrDefault();

            db.GuiaProductos.Remove(guiaProducto);
            db.SaveChanges();

            return eliminar;
        }

        public List<GuiaProductoDTO> ListGuiaProducto(int GuiaId)
        {
            List<GuiaProductoDTO> guiaProductos = (from g in db.GuiaProductos
                                                   where g.GuiaId == GuiaId
                                                   select new GuiaProductoDTO()
                                                   {
                                                       GuiaProductoId = g.GuiaProductoId,
                                                       GuiaId = g.GuiaId,
                                                       ProductoId = g.ProductoId,
                                                       CantidadProducto = g.CantidadProducto,
                                                       DescripcionGuiaProducto = g.DescripcionGuiaProducto,
                                                       FechaRegistro = g.FechaRegistro,
                                                       PrecioEnvio = g.PrecioEnvio

                                                   }).ToList();
            return guiaProductos;
        }

        public List<ClienteDTO> ListCliente()
        {
            List<ClienteDTO> clientes = (from g in db.Clientes
                                                   select new ClienteDTO()
                                                   {
                                                       ClienteId = g.ClienteId,
                                                       Nombre = g.Nombre + " " + g.Apellido,

                                                   }).ToList();
            return clientes;
        }

        public List<BodegaDTO> ListBodega()
        {
            List<BodegaDTO> bodegas = (from g in db.Bodegas
                                         select new BodegaDTO()
                                         {
                                             BodegaId = g.BodegaId,
                                             DescripcionBodega = g.DescripcionBodega,

                                         }).ToList();
            return bodegas;
        }
        public List<TipoGuiaDTO> ListTipoGuia()
        {
            List<TipoGuiaDTO> tipoGuias = (from g in db.TipoGuia
                                       select new TipoGuiaDTO()
                                       {
                                           TipoGuiaId = g.TipoGuiaId,
                                           DescripcionTipoGuia = g.DescripcionTipoGuia,

                                       }).ToList();
            return tipoGuias;
        }

        #endregion

        private bool validateConsecutivo(int TipoGuia, string consecutivo)
        {
            bool Respuesta = false;
            //Id 2 = Terrestre
            if (TipoGuia == 2)
            {   //contador que me indica el paso de las primeras 3 vueltas que son letras 
                int contado = 0;
                if (consecutivo.Length == 8)
                {
                    foreach (char l in consecutivo)
                    {
                        contado++;
                        if (contado <= 3)
                        {
                            int numericValue;
                            bool isNumber = int.TryParse(l.ToString(), out numericValue);
                            if (isNumber)
                            {
                                Respuesta = false;
                                break;
                            }
                        }
                        else if (contado <= 4 && contado <= 7)
                        {
                            int numericValue;
                            bool isNumber = int.TryParse(l.ToString(), out numericValue);
                            if (isNumber!)
                            {
                                Respuesta = false;
                                break;
                            }
                        }
                        else
                        {
                            int numericValue;
                            bool isNumber = int.TryParse(l.ToString(), out numericValue);
                            if (isNumber)
                            {
                                Respuesta = false;
                                break;
                            }
                        }

                    }
                }
                else
                {
                    return Respuesta;
                }
            }

            return Respuesta;
        }
        private string CreadorGuia()
        {   //retorno un cadena de longitud 10, validar contra la base si existe 
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var Charsarr = new char[10];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(Charsarr);

            return resultString;
        }

    }
}
