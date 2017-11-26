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
    public class RoleDA:IEntity<Role>
    {
        public Role GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Add(Role entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Role entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
