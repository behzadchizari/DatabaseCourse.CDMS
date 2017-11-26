using System.Collections.Generic;

namespace DatabaseCourse.Common.Interface
{
    public interface IEntity<T>
    {
        T GetById(int id);
        List<T> GetAll();
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
