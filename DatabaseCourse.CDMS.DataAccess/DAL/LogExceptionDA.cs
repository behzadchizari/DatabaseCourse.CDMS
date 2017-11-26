using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCourse.CDMS.DataAccess.Context;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Interface;

namespace DatabaseCourse.CDMS.DataAccess.DAL
{
    // ReSharper disable once InconsistentNaming
    public class LogExceptionDA:IEntity<LogException>

    {
        private CDMSEntities _context = new CDMSEntities();

        public IQueryable<LogException> GetById(int id)
        {
            try
            {
                return _context?.LogException?.Where(x => x.Id == id) ?? null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IQueryable<LogException> GetAll()
        {
            try
            {
                return _context?.LogException?.Select(x=>x) ?? null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public int Add(LogException role)
        {
            try
            {
                _context?.LogException?.Add(role);
                _context?.SaveChanges();
                return role.Id;
            }
            catch (Exception e)
            {
                return 0;
            }
            
        }

        public int Update(LogException entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(LogException role)
        {
            throw new NotImplementedException();
        }
    }
}
