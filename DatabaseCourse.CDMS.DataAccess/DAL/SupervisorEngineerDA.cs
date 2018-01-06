using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.DataAccess.DAL
{
    public class SupervisorEngineerDA
    {
        private CDMSEntities _context = new CDMSEntities();

        public int Add(SupervisorEngineer entity)
        {
            _context?.SupervisorEngineer?.Add(entity);
            _context?.SaveChanges();
            return entity?.Id ?? 0;
        }

        public int Delete(SupervisorEngineer entity)
        {
            var id = entity?.Id ?? 0;
            if (id == 0) return id;
            _context?.SupervisorEngineer?.Remove(entity);
            _context?.SaveChanges();
            return id;
        }

        public IQueryable<SupervisorEngineer> GetAll()
        {
            return _context?.SupervisorEngineer?.AsQueryable();
        }

        public IQueryable<SupervisorEngineer> GetById(int id)
        {
            return _context?.SupervisorEngineer?.Where(x => x.Id == id);
        }

        public int Update(SupervisorEngineer entity)
        {
            var newEntity = _context?.SupervisorEngineer?.FirstOrDefault(x => x.Id == entity.Id);
            if (newEntity == null)
                throw new Exception("Exception Occured on Updating Contractor. Contractor not Found");
            newEntity.EngineeringCode = entity?.EngineeringCode ?? newEntity.EngineeringCode;
            newEntity.FirstName = entity?.FirstName ?? newEntity.FirstName;
            newEntity.LastName= entity?.LastName ?? newEntity.LastName;
            newEntity.PhoneNumber = entity?.PhoneNumber ?? newEntity.PhoneNumber;
            _context.SaveChanges();
            return newEntity?.Id ?? 0;
        }
    }
}
