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
    public class UserRoleDA : IEntity<UserRole>
    {
        public UserRole GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserRole> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Add(UserRole role)
        {
            throw new NotImplementedException();
        }

        public int Update(UserRole entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(UserRole role)
        {
            throw new NotImplementedException();
        }
    }
}
