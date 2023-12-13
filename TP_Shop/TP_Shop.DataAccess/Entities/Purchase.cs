using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Shop.DataAccess.Entities
{
    public class Purchase
    {
        public int Id { get; set; }

        public string Person { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateTime Date { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; } = null!;
    }
}
