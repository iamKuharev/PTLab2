﻿using System;
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
    public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(ShopContext db) : base(db)
        {
        }
    }
}
