using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.DataAccess.DAL
{
    class CooperationContractDA
    {
        private CDMSEntities _context = new CDMSEntities();

        public int Add(CooperationContract entity)
        {
            _context?.CooperationContract?.Add(entity);
            _context?.SaveChanges();
            return entity?.Id ?? 0;
        }

        public int Delete(CooperationContract entity)
        {
            var id = entity?.Id ?? 0;
            if (id == 0) return id;
            _context?.CooperationContract?.Remove(entity);
            _context?.SaveChanges();
            return id;
        }

        public IQueryable<CooperationContract> GetAll()
        {
            return _context?.CooperationContract?.AsQueryable();
        }

        public IQueryable<CooperationContract> GetById(int id)
        {
            return _context?.CooperationContract?.Where(x => x.Id == id);
        }

        public int Update(CooperationContract entity)
        {
            var newEntity = _context?.CooperationContract?.FirstOrDefault(x => x.Id == entity.Id);
            if (newEntity == null)
                throw new Exception("Exception Occured on Updating CooperationContract. CooperationContract not Found");
            newEntity.EndDate = entity?.EndDate ?? newEntity.EndDate;
            newEntity.StartDate= entity?.StartDate ?? newEntity.StartDate;
            _context.SaveChanges();
            return newEntity?.Id ?? 0;
        }
    }
}
