using System;
using System.Linq;
using System.Linq.Expressions;

namespace CompanyPropertyManagement.DataAccessLayer.IRepositories
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindAllByCondition(Expression<Func<T, bool>> expression);
        T FindById(Guid Id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
