using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Shop.DataAccess.Entities
{
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public int Price { get; set; }

        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

        public ICollection<PromoСode> PromoСode { get; set; } = new List<PromoСode>();
    }
}
