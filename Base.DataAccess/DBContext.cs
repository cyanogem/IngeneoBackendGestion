using System.Linq;
using BaseAPI.Abstraction;
using BaseAPI.Abstraction.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BaseAPI.DataAccess
{
    public class DBContext<T> : IDBContext<T> where T : class,IEntity
    {
        ILogger _logger;
        APIDBContext _context;
        DbSet<T> _items;

        public DBContext(ILogger<DBContext<T>> _logger, APIDBContext ctx )
        {
            this._context = ctx; 
            this._items = ctx.Set<T>();
            this._logger = _logger;
        }



        public T GetById(int id)
        {
            return _items.Find(id);
        }

        public IList<T> GetAllByPage(int _page, int _countByPage)
        {
            var _pageCount = Math.Ceiling(this._items.Count() / Convert.ToDecimal(_countByPage));
            _logger.LogInformation("En DBContext mensaje!!!");
            return _items
                .Skip((_page - 1) * (int)_countByPage)
                .Take((int)_countByPage)
                .ToList();
        }


        public IList<T> GetAll()
        {
            _logger.LogInformation("En DBContext mensaje!!!");
            return _items.ToList();
        }


        public T Save(T entity)
        {
            _items.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _items.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public void DeleteById(int id)
        {
            T t = GetById(id);
            _items.Remove(t);
            _context.SaveChanges();
            return;
        }

    }
}