using DcPet.Data.IWorkUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcPet.Data
{
    public class WorkUnit : IWorkUnit.IWorkUnit
    {
        public DcPetEntities db { get; set; }

        public WorkUnit() {
            db = new DcPetEntities();
        }

        public int Save() {
            return db.SaveChanges();
        }

        public void SqlQuery<T>(string sql,params object[] param) {
            db.Database.SqlQuery<T>(sql, param);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
