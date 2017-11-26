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
    public class UserDA : IEntity<User>
    {
        private CDMSEntities _context = new CDMSEntities();

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Add(User role)
        {
            throw new NotImplementedException();
        }

        public int Update(User entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(User role)
        {
            throw new NotImplementedException();
        }
    }
}
