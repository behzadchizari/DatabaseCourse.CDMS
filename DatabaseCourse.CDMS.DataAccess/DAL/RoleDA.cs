using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCourse.CDMS.DataAccess.Context;
using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Interface;

namespace DatabaseCourse.CDMS.DataAccess.DAL
{
    // ReSharper disable once InconsistentNaming
    public class RoleDA : IEntity<Role>
    {
        private CDMSEntities _context = new CDMSEntities();

        public Role GetById(int id)
        {
            return _context?.Role?.FirstOrDefault(x => x.Id == id) ?? null;
        }

        public List<Role> GetAll()
        {
            return _context?.Role?.ToList();
        }

        public int Add(Role role)
        {
            _context?.Role?.Add(role);
            _context?.SaveChanges();
            return role?.Id ?? 0;
        }

        public int Update(Role role)
        {
            var newEntity = _context?.Role?.FirstOrDefault(x => x.Id == role.Id);
            if (newEntity != null)
            {
                newEntity.DisplayName = role?.DisplayName;
                newEntity.Title = role?.Title;
                newEntity.UserRole = role?.UserRole;
                _context.SaveChanges();
                return newEntity?.Id ?? 0;
            }
            else
            {
                throw new Exception("Exception Occured on Updating Role. Role not Found");
            }

        }

        public int Delete(Role role)
        {
            var id = role?.Id ?? 0;
            _context.Role.Remove(role ?? throw new Exception("Exception Occured on Deleting Role. Role not Found"));
            _context.SaveChanges();
            return id;
        }
    }
}
