using DatabaseCourse.CDMS.DataAccess.Model;
using DatabaseCourse.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCourse.CDMS.DataAccess.DAL
{
    public class ExpenseDA 
    {
        private CDMSEntities _context = new CDMSEntities();

        public int Add(Expense entity)
        {
            entity.RequestDate = DateTime.Now;
            _context?.Expense?.Add(entity);
            _context?.SaveChanges();
            return entity?.Id ?? 0;
        }

        public int Delete(Expense entity)
        {
            var id = entity?.Id ?? 0;
            if (id == 0) return id;
            _context?.Expense?.Remove(entity);
            _context?.SaveChanges();
            return id;
        }

        public IQueryable<Expense> GetAll()
        {
            return _context?.Expense?.AsQueryable();
        }

        public IQueryable<Expense> GetById(int id)
        {
            return _context?.Expense?.Where(x => x.Id == id);
        }

        public int Update(Expense entity)
        {
            //TODO
            var newEntity = _context?.Expense?.FirstOrDefault(x => x.Id == entity.Id);
            if (newEntity == null)
                throw new Exception("Exception Occured on Updating Expense. Expense not Found");
            newEntity.Buyer = entity?.Buyer ?? newEntity.Buyer;
            newEntity.SubmittedDate = entity?.SubmittedDate ?? newEntity.SubmittedDate;
            newEntity.Seller = entity?.Seller ?? newEntity.Seller;
            _context.SaveChanges();
            return newEntity?.Id ?? 0;
        }
    }
}
