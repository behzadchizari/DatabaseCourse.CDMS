using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.DataAccess.DAL
{
    public class LeaveDA 
    {
        private CDMSEntities _context = new CDMSEntities();

        public int Add(Leave entity)
        {
            _context?.Leave?.Add(entity);
            _context?.SaveChanges();
            return entity?.Id ?? 0;
        }
        public int Delete(Leave entity)
        {
            var id = entity?.Id ?? 0;
            if (id == 0) return id;
            _context?.Leave?.Remove(entity);
            _context?.SaveChanges();
            return id;
        }
        public IQueryable<Leave> GetById(int id)
        {
            return _context?.Leave?.Where(x => x.Id == id);
        }
        public IQueryable<Leave> GetByCooperationContractId(int cooperationContractId)
        {
            return _context?.Leave?.Where(x => x.CooperationContractId == cooperationContractId);
        }
    }
}
