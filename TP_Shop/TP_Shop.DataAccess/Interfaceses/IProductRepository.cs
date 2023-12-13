using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Shop.DataAccess.Entities;
using TP_Shop.DataAccess.Interfaceses.Base;

namespace TP_Shop.DataAccess.Interfaceses
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        public IEnumerable<Product> GetByPromoCode(string promoCode);
    }
}
