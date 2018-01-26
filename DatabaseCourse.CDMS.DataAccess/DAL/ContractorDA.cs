using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.DataAccess.DAL
{
    public class ContractorDA
    {
        private CDMSEntities _context = new CDMSEntities();

        public int Add(Contractor entity)
        {
            _context?.Contractor?.Add(entity);
            _context?.SaveChanges();
            return entity?.Id ?? 0;
        }

        public int Delete(Contractor entity)
        {
            var id = entity?.Id ?? 0;
            if (id == 0) return id;
            _context?.Contractor?.Remove(entity);
            _context?.SaveChanges();
            return id;
        }

        public IQueryable<Contractor> GetAll()
        {
            return _context?.Contractor?.AsQueryable();
        }

        public Contractor GetById(int id)
        {
            return _context?.Contractor?.FirstOrDefault(x => x.Id == id);
        }

        public int Update(Contractor entity)
        {
            var newEntity = _context?.Contractor?.FirstOrDefault(x => x.Id == entity.Id);
            if (newEntity == null)
                throw new Exception("Exception Occured on Updating Contractor. Contractor not Found");
            newEntity.Contact = entity?.Contact ?? newEntity.Contact;
            newEntity.FirstName = entity?.FirstName?? newEntity.FirstName;
            newEntity.LastName = entity?.LastName?? newEntity.LastName;
            newEntity.InsuranceNo = entity?.InsuranceNo?? newEntity.InsuranceNo;
            newEntity.Nationalid = entity?.Nationalid?? newEntity.Nationalid;
            _context.SaveChanges();
            return newEntity?.Id ?? 0;
        }
    }
}
