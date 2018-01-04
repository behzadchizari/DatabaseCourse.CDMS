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
using DatabaseCourse.Common.Enums;
using DatabaseCourse.Common.Utility.EnumUtility;
namespace DatabaseCourse.CDMS.DataAccess.DAL
{
    // ReSharper disable once InconsistentNaming
    public class UserDA
    {
        private CDMSEntities _context = new CDMSEntities();

        public IQueryable<User> GetById(int id)
        {
            return _context?.User?.Where(x => x.Id == id);
        }

        public IQueryable<User> GetAll()
        {
            return _context?.User?.AsQueryable();
        }

        public int Add(User entity, List<UserRoleEnum> userRoleList)
        {
            entity.CreationDate = DateTime.Now;
            entity.LastModifyDate = DateTime.Now;
            _context?.User?.Add(entity);
            _context?.SaveChanges();
            var addedId = entity?.Id ?? 0;
            if (addedId != 0)
            {
                var userRoleDA = new UserRoleDA();
                foreach (var item in userRoleList)
                {
                    userRoleDA.Add(new UserRole
                    {
                        Role_Id = EnumUtility.GetEnumValue(item),
                        User_Id = addedId
                    });
                }
            }
            else addedId = 0;
            return addedId;
        }

        public int Update(User entity)
        {
            var newEntity = _context?.User?.FirstOrDefault(x => x.Id == entity.Id);
            if (newEntity == null)
                throw new Exception("Exception Occured on Updating User. User not Found");
            newEntity.Username = entity?.Username?? newEntity.Username;
            newEntity.LastModifyDate = DateTime.Now;
            newEntity.LastName = entity?.LastName?? newEntity.LastName;
            newEntity.FirstName= entity?.FirstName?? newEntity.FirstName;
            newEntity.Password = entity?.Password ?? newEntity.Password;
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
