using DatabaseCourse.CDMS.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.DataAccess
{
    class DatabaseInitializer: DropCreateDatabaseAlways<CDMSEntities>
    {
        protected override void Seed(CDMSEntities context)
        {
            base.Seed(context);
        }
    }
}
