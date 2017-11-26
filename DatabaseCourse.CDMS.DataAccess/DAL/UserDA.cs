using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
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

        public IQueryable<User> GetById(int id)
        {
            return _context?.User?.AsNoTracking().Where(x => x.Id == id);
        }

        public IQueryable<User> GetAll()
        {
            return _context?.User?.AsNoTracking().Select(x => x);
        }

        public int Add(User entity)
        {
            _context?.User?.Add(entity);
            _context?.SaveChanges();
            return entity?.Id ?? 0;
        }

        public int Update(User entity)
        {
            var newEntity = _context?.User?.FirstOrDefault(x => x.Id == entity.Id);
            if (newEntity == null)
                throw new Exception("Exception Occured on Updating User. User not Found");
            newEntity.Username = entity?.Username;
            newEntity.LastModifyDate = DateTime.Now;
            newEntity.Password = entity?.Password;
            newEntity.LastModifyUser = entity?.LastModifyUser;
            _context.SaveChanges();
            return newEntity?.Id ?? 0;
        }

        public int Delete(User user)
        {
            var id = user?.Id ?? 0;
            if (id == 0) return id;
            _context?.User?.Remove(user);
            _context?.SaveChanges();
            return id;
        }
    }
}
