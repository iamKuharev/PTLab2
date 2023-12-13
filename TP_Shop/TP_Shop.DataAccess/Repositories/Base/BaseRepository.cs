using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Shop.DataAccess.EF;
using TP_Shop.DataAccess.Interfaceses.Base;

namespace TP_Shop.DataAccess.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ShopContext _db;

        private readonly DbSet<T> _dbSet;
        public BaseRepository(ShopContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _db.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public T? GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _db.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _db.SaveChanges();
        }
    }
}
