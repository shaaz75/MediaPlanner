using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlanner.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
       
        DemoContext dbContext;

        public DemoContext Init()
        {
            return dbContext ?? (dbContext = new DemoContext());
        }

        //protected override void DisposeCore()
        //{
        //    if (dbContext != null)
        //        dbContext.Dispose();
        //}
    }
}
