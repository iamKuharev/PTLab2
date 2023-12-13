using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Shop.DataAccess.Interfaceses.Base
{
    public interface IBaseRepository<T> where T : class
    {
        public void Create(T entity);

        public IEnumerable<T> GetAll();

        public T? GetById(long id);

        public void Update(T entity);

        public void Delete(T entity);
    }
}
