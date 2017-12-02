using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCourse.CDMS.DataAccess.Context;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Interface;
using DatabaseCourse.Common.Utility;

namespace DatabaseCourse.CDMS.DataAccess.DAL
{
    // ReSharper disable once InconsistentNaming
    public class UserRoleDA
    {
        private CDMSEntities _context = new CDMSEntities();

        public IQueryable<UserRole> GetById(int id)
        {
            return _context?.UserRole?.AsNoTracking().Where(x => x.Id == id) ?? null;
        }

        public IQueryable<UserRole> GetAll()
        {
            return _context?.UserRole?.AsNoTracking().Select(x => x) ?? null;

        }
        public int Add(UserRole entity)
        {
            _context?.UserRole?.Add(entity);
            _context?.SaveChanges();
            return entity?.Id ?? 0;
        }

        public int Update(UserRole entity)
        {
            var newEntity = _context?.UserRole?.FirstOrDefault(x => x.Id == entity.Id);
            if (newEntity == null)
                throw new Exception("Exception Occured on Updating UserRole. UserRole not Found");
            newEntity.Role_Id =TypeUtility.ConvertToInt( entity?.Role_Id);
            newEntity.User_Id = TypeUtility.ConvertToInt(entity?.User_Id);
            _context.SaveChanges();
            return newEntity?.Id ?? 0;
        }

        public int Delete(UserRole entity)
        {
            var id = entity?.Id ?? 0;
            if (id == 0) return id;
            _context?.UserRole?.Remove(entity);
            _context?.SaveChanges();
            return id;
        }

    }
}
