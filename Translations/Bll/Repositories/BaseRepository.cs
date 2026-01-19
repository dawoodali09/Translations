using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Bll.Repositories
{
    public class BaseRepository
    {
         protected Entities DbContext;

        public BaseRepository()
        {
            DbContext = new Entities();
        }

        public BaseRepository(Entities dbContext)
        {
            DbContext = dbContext;
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        #region IDisposable Implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (DbContext != null)
                {
                    DbContext.Dispose();
                    DbContext = null;
                }
        }

        ~BaseRepository()
        {
            Dispose(false);
        }

        #endregion IDisposable Implementation
    }
}
