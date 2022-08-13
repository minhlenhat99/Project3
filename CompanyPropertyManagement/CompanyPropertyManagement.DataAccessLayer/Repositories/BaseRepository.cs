using CompanyPropertyManagement.Data.Context;
using CompanyPropertyManagement.DataAccessLayer.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CompanyPropertyManagement.DataAccessLayer.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public virtual IQueryable<T> FindAll() => _dbSet;
        public virtual IQueryable<T> FindAllByCondition(Expression<Func<T, bool>> expression) => _dbSet.Where(expression);
        public virtual T FindById(Guid Id) => _dbSet.Find(Id);
        public virtual void Create(T entity) => _dbSet.Add(entity);
        public virtual void Update(T entity) => _dbSet.Update(entity);
        public virtual void Delete(T entity) => _dbSet.Remove(entity);
    }
}
