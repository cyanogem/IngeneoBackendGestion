using Base.Abstraction.DTO.Guia;
using Base.Entity.Dominio;
using BaseAPI.Abstraction.DBContext;
using BaseAPI.DataAccess;
using BaseAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Base.Repository.Dominio
{
    public class TerrestreRepository<T> : ARepositoryBase<T> where T : Guium
    {
        ILogger logger;
        IDBContext<T> dbctx;
        APIDBContext db;
        public TerrestreRepository(ILogger<TerrestreRepository<T>> _logger, IDBContext<T> _ctx, APIDBContext _db) : base(_logger, _ctx, _db)
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
                                                               where g.Guia.TipoGuiaId == 2
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

                db.Guia.Add(guium);

                db.SaveChanges();
            }
            else
            {
                Guium guium1 = db.Guia.Where(r => r.GuiaId == guiaDTO.GuiaId).FirstOrDefault();

                guium1.ClienteId = guiaDTO.ClienteId;
                guium1.FechaEntrega = guiaDTO.FechaEntrega;
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
                                      where g.TipoGuiaId == 2
                                      select new GuiaDTO()
                                      {
                                          ClienteId = g.ClienteId,
                                          FechaEntrega = g.FechaEntrega,
                                          BodegaId = g.BodegaId,
                                          TipoGuiaId = g.TipoGuiaId,
                                          Consecutivo = g.Consecutivo,
                                          NumeroGuia = g.NumeroGuia,
                                          Bodega = g.Bodega.DescripcionBodega,
                                          TipoGuia = g.TipoGuia.DescripcionTipoGuia

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
                    guiaProducto.PrecioEnvio = guiaProductoDTO.PrecioEnvio - (guiaProductoDTO.PrecioEnvio * (decimal)0.05);
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
        public GuiaProductoDTO GetGuiaProductoBy(int GuiaProductoId)
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
        public int DeleteGuiaProducto(int eliminar)
        {
            GuiaProducto guiaProducto = db.GuiaProductos.Where(x => x.GuiaProductoId == eliminar).FirstOrDefault();

            db.GuiaProductos.Remove(guiaProducto);
            db.SaveChanges();

            return eliminar;
        }
        #endregion

        #region Cliente

        public ClienteDTO SaveCliente(ClienteDTO clienteDTO)
        {
            Cliente cliente;
            cliente = new Cliente();
            //Valido si el obejto viene para ser creado o editado 
            if (clienteDTO.ClienteId == 0)
            {
                cliente.ClienteId = clienteDTO.ClienteId;
                cliente.Nombre = clienteDTO.Nombre;
                cliente.Apellido = clienteDTO.Apellido;
                cliente.Cedula = clienteDTO.Cedula;
                cliente.Telefono = clienteDTO.Telefono;
                cliente.Direccion = clienteDTO.Direccion;

                db.Clientes.Add(cliente);

                db.SaveChanges();
            }
            else
            {
                Cliente cliente1 = db.Clientes.Where(r => r.ClienteId == clienteDTO.ClienteId).FirstOrDefault();

                cliente1.Nombre = clienteDTO.Nombre;
                cliente1.Apellido = clienteDTO.Apellido;
                cliente1.Cedula = clienteDTO.Cedula;
                cliente1.Telefono = clienteDTO.Telefono;
                cliente1.Direccion = clienteDTO.Direccion;

                db.Entry(cliente1).State = EntityState.Modified;
                db.SaveChanges();

            }
            return clienteDTO;
        }
        public ClienteDTO GetClienteBy(int ClienteId)
        {
            ClienteDTO? clienteDTO = (from g in db.Clientes
                                      where g.ClienteId == ClienteId
                                      select new ClienteDTO()
                                      {
                                          ClienteId = g.ClienteId,
                                          Nombre = g.Nombre,
                                          Apellido = g.Apellido,
                                          Cedula = g.Cedula,
                                          Telefono = g.Telefono,
                                          Direccion = g.Direccion,

                                      }).FirstOrDefault();
            return clienteDTO;
        }
        public List<ClienteDTO> ListCliente()
        {
            List<ClienteDTO> clienteDTOs = (from g in db.Clientes

                                            select new ClienteDTO()
                                            {
                                                ClienteId = g.ClienteId,
                                                Nombre = g.Nombre,
                                                Apellido = g.Apellido,
                                                Cedula = g.Cedula,
                                                Telefono = g.Telefono,
                                                Direccion = g.Direccion,

                                            }).ToList();
            return clienteDTOs;
        }
        public int DeleteCliente(int eliminar)
        {
            Cliente cliente = db.Clientes.Where(x => x.ClienteId == eliminar).FirstOrDefault();

            db.Clientes.Remove(cliente);
            db.SaveChanges();

            return eliminar;
        }

        #endregion

        #region Bodega

        public BodegaDTO SaveBodega(BodegaDTO bodegaDTO)
        {
            Bodega bodega;
            bodega = new Bodega();
            //Valido si el obejto viene para ser creado o editado 
            if (bodegaDTO.BodegaId == 0)
            {
                bodega.DescripcionBodega = bodegaDTO.DescripcionBodega;
                bodega.Activo = bodegaDTO.Activo;

                db.Bodegas.Add(bodega);

                db.SaveChanges();
            }
            else
            {
                Bodega bodega1 = db.Bodegas.Where(r => r.BodegaId == bodegaDTO.BodegaId).FirstOrDefault();

                bodega.DescripcionBodega = bodegaDTO.DescripcionBodega;
                bodega.Activo = bodegaDTO.Activo;

                db.Entry(bodega1).State = EntityState.Modified;
                db.SaveChanges();

            }
            return bodegaDTO;
        }
        public BodegaDTO GetBodegaBy(int BodegaId)
        {
            BodegaDTO? bodegaDTO = (from g in db.Bodegas
                                    where g.BodegaId == BodegaId
                                    select new BodegaDTO()
                                    {
                                        BodegaId = g.BodegaId,
                                        DescripcionBodega = g.DescripcionBodega,
                                        Activo = g.Activo

                                    }).FirstOrDefault();
            return bodegaDTO;
        }
        public List<BodegaDTO> ListBodega()
        {
            List<BodegaDTO> bodegaDTOs = (from g in db.Bodegas

                                          select new BodegaDTO()
                                          {
                                              BodegaId = g.BodegaId,
                                              DescripcionBodega = g.DescripcionBodega,
                                              Activo = g.Activo

                                          }).ToList();
            return bodegaDTOs;
        }
        public int DeleteBodega(int eliminar)
        {
            Bodega bodega = db.Bodegas.Where(x => x.BodegaId == eliminar).FirstOrDefault();

            db.Bodegas.Remove(bodega);
            db.SaveChanges();

            return eliminar;
        }

        #endregion

        #region TipoGuia

        public TipoGuiaDTO SaveTipoGuia(TipoGuiaDTO tipoGuiaDTO)
        {
            TipoGuium tipoGuium;
            tipoGuium = new TipoGuium();
            //Valido si el obejto viene para ser creado o editado 
            if (tipoGuiaDTO.TipoGuiaId == 0)
            {
                tipoGuium.DescripcionTipoGuia = tipoGuiaDTO.DescripcionTipoGuia;
                tipoGuium.Activo = tipoGuiaDTO.Activo;

                db.TipoGuia.Add(tipoGuium);

                db.SaveChanges();
            }
            else
            {
                TipoGuium tipoGuium1 = db.TipoGuia.Where(r => r.TipoGuiaId == tipoGuiaDTO.TipoGuiaId).FirstOrDefault();

                tipoGuium1.DescripcionTipoGuia = tipoGuiaDTO.DescripcionTipoGuia;
                tipoGuium1.Activo = tipoGuiaDTO.Activo;

                db.Entry(tipoGuium1).State = EntityState.Modified;
                db.SaveChanges();

            }
            return tipoGuiaDTO;
        }
        public TipoGuiaDTO GetTipoGuiaBy(int TipoGuiaId)
        {
            TipoGuiaDTO? tipoGuiaDTO = (from g in db.TipoGuia
                                        where g.TipoGuiaId == TipoGuiaId
                                        select new TipoGuiaDTO()
                                        {
                                            TipoGuiaId = g.TipoGuiaId,
                                            DescripcionTipoGuia = g.DescripcionTipoGuia,
                                            Activo = g.Activo

                                        }).FirstOrDefault();
            return tipoGuiaDTO;
        }
        public List<TipoGuiaDTO> ListTipoGuia(decimal TipoGuiaId)
        {
            List<TipoGuiaDTO> tipoGuiaDTOs = (from g in db.TipoGuia
                                              where g.TipoGuiaId == TipoGuiaId
                                              select new TipoGuiaDTO()
                                              {
                                                  TipoGuiaId = g.TipoGuiaId,
                                                  DescripcionTipoGuia = g.DescripcionTipoGuia,
                                                  Activo = g.Activo

                                              }).ToList();
            return tipoGuiaDTOs;
        }
        public int DeleteTipoGuia(int eliminar)
        {
            TipoGuium tipoGuium = db.TipoGuia.Where(x => x.TipoGuiaId == eliminar).FirstOrDefault();

            db.TipoGuia.Remove(tipoGuium);
            db.SaveChanges();

            return eliminar;
        }

        #endregion

        #region Producto

        public ProductoDTO SaveProducto(ProductoDTO productoDTO)
        {
            Producto producto;
            producto = new Producto();
            //Valido si el obejto viene para ser creado o editado 
            if (productoDTO.ProductoId == 0)
            {
                producto.TipoProductoId = productoDTO.TipoProductoId;
                producto.DescripcionProducto = productoDTO.DescripcionProducto;
                producto.Activo = productoDTO.Activo;
                producto.Precio = productoDTO.Precio;

                db.Productos.Add(producto);

                db.SaveChanges();
            }
            else
            {
                Producto producto1 = db.Productos.Where(r => r.ProductoId == productoDTO.ProductoId).FirstOrDefault();

                producto1.TipoProductoId = productoDTO.TipoProductoId;
                producto1.DescripcionProducto = productoDTO.DescripcionProducto;
                producto1.Activo = productoDTO.Activo;
                producto1.Precio = productoDTO.Precio;

                db.Entry(producto1).State = EntityState.Modified;
                db.SaveChanges();

            }
            return productoDTO;
        }
        public ProductoDTO GetProductoBy(int ProductoId)
        {
            ProductoDTO? productoDTO = (from g in db.Productos
                                        where g.ProductoId == ProductoId
                                        select new ProductoDTO()
                                        {
                                            ProductoId = g.ProductoId,
                                            TipoProductoId = g.TipoProductoId,
                                            DescripcionProducto = g.DescripcionProducto,
                                            Precio = g.Precio,
                                            Activo = g.Activo

                                        }).FirstOrDefault();
            return productoDTO;
        }
        public List<ProductoDTO> ListProducto()
        {
            List<ProductoDTO> productoDTOs = (from g in db.Productos
                                              where g.Activo == true
                                              select new ProductoDTO()
                                              {
                                                  ProductoId = g.ProductoId,
                                                  TipoProductoId = g.TipoProductoId,
                                                  DescripcionProducto = g.DescripcionProducto,
                                                  Precio = g.Precio,
                                                  Activo = g.Activo,
                                                  TipoProducto = g.TipoProducto.DescripcionTipoProducto

                                              }).ToList();
            return productoDTOs;
        }
        public int DeleteProducto(int eliminar)
        {
            Producto producto = db.Productos.Where(x => x.ProductoId == eliminar).FirstOrDefault();

            db.Productos.Remove(producto);
            db.SaveChanges();

            return eliminar;
        }

        #endregion

        private bool validateConsecutivo(int TipoGuia, string consecutivo)
        {
            bool Respuesta = false;
            //Id 2 = Terrestre
            if (TipoGuia == 1)
            {   //contador que me indica el paso de las primeras 3 vueltas que son letras 
                int contado = 0;
                //mirar la longitud del consecutivo
                if (consecutivo.Length == 6)
                {
                    foreach (char l in consecutivo)
                    {
                        contado++;
                        //Validador de las primeras 3 letras 
                        if (contado <= 3)
                        {

                            int numericValue;
                            bool isNumber = int.TryParse(l.ToString(), out numericValue);
                            // como las primeras 3 son letras, si es un numero entra el if y devuelve un false indicando que no es valido el consecutivo
                            if (isNumber)
                            {
                                Respuesta = false;
                                break;
                            }
                        }
                        else
                        {
                            int numericValue;
                            bool isNumber = int.TryParse(l.ToString(), out numericValue);
                            //validador para indicar que las ultimas tiene que ser numero , como la respuesta es true , si es false entra al if y lo detiene 
                            if (isNumber!)
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
