using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Shop.DataAccess.EF;
using TP_Shop.DataAccess.Entities;
using TP_Shop.DataAccess.Interfaceses;
using TP_Shop.DataAccess.Repositories.Base;

namespace TP_Shop.DataAccess.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ShopContext db) : base(db)
        {
            
        }

        public IEnumerable<Product> GetByPromoCode(string promoCode)
        {
            return _db.Products.Where(p => p.PromoСode.Any(pc => pc.Name == promoCode) || p.PromoСode.Count == 0);
        }
    }
}
