using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCham.Data.Infrastructure
{
    public class DbFactory : IDisposable, IDbFactory
    {
        private ShopChamDbContext dbContext;

        public void Dispose()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

        public ShopChamDbContext Init()
        {
            return dbContext ?? (dbContext = new ShopChamDbContext());
        }
    }
}
