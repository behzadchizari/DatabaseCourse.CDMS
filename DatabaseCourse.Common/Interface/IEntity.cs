using System.Collections.Generic;
using System.Linq;

namespace DatabaseCourse.Common.Interface
{
    public interface IEntity<T>
    {
        /// <summary>
        /// Select All of
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IQueryable<T> GetById(int id);
        IQueryable<T> GetAll();
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
