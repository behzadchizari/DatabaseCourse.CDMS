using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Interface;

namespace DatabaseCourse.CDMS.DataAccess.DAL
{
    // ReSharper disable once InconsistentNaming
    public class LogExceptionDA:IEntity<LogException>

    {
        public LogException GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<LogException> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Add(LogException entity)
        {
            throw new NotImplementedException();
        }

        public int Update(LogException entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(LogException entity)
        {
            throw new NotImplementedException();
        }
    }
}
