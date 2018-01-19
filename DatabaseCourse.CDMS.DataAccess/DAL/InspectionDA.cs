using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.DataAccess.DAL
{
    public class InspectionDA
    {
        private CDMSEntities _context = new CDMSEntities();

        public int Add(Inspection entity)
        {
            _context?.Inspection?.Add(entity);
            _context?.SaveChanges();
            return entity?.Id ?? 0;
        }

        public int Delete(Inspection entity)
        {
            var id = entity?.Id ?? 0;
            if (id == 0) return id;
            _context?.Inspection?.Remove(entity);
            _context?.SaveChanges();
            return id;
        }

        public IQueryable<Inspection> GetById(int id)
        {
            return _context?.Inspection?.Where(x => x.Id == id);
        }
        public IQueryable<Inspection> GetByProjectId(int projectId)
        {
            return _context?.Inspection?.Where(x => x.ProjectId == projectId);
        }
    }
}
