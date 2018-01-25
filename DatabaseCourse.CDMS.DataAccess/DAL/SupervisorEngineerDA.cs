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

        public SupervisorEngineer GetById(int id)
        {
            return _context?.SupervisorEngineer?.FirstOrDefault(x => x.Id == id);
        }

        public SupervisorEngineer GetByName(string name)
        {
            return _context?.SupervisorEngineer?.FirstOrDefault(x => x.FullName == name);
            
        }

        public SupervisorEngineer FindByName(string name)
        {
            var se = _context?.SupervisorEngineer?.FirstOrDefault(x => x.FullName == name);
            if(se == null)
            {
                var entity = new SupervisorEngineer()
                {
                    FullName = name
                };
                _context?.SupervisorEngineer?.Add(entity);
                _context?.SaveChanges();
                return entity;
            }
            else
            {
                return se;
            }
        }

        public int Update(SupervisorEngineer entity)
        {
            var newEntity = _context?.SupervisorEngineer?.FirstOrDefault(x => x.Id == entity.Id);
            if (newEntity == null)
                throw new Exception("Exception Occured on Updating Contractor. Contractor not Found");
            newEntity.EngineeringCode = entity?.EngineeringCode ?? newEntity.EngineeringCode;
            newEntity.FullName = entity?.FullName ?? newEntity.FullName;
            newEntity.PhoneNumber = entity?.PhoneNumber ?? newEntity.PhoneNumber;
            _context.SaveChanges();
            return newEntity?.Id ?? 0;
        }
    }
}
