using CompanyPropertyManagement.Data.Context;
using CompanyPropertyManagement.Data.Domain;
using CompanyPropertyManagement.DataAccessLayer.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CompanyPropertyManagement.DataAccessLayer.Repositories
{
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override IQueryable<Property> FindAll() => _dbSet.Include(p => p.Category)
            .Include(p => p.SeatCode)
            .ThenInclude(s => s.BU);
        public override IQueryable<Property> FindAllByCondition(Expression<Func<Property, bool>> expression)
            => _dbSet.Where(expression)
                    .Include(p => p.Category)
                    .Include(p => p.SeatCode)
                    .ThenInclude(s => s.BU);
    }
}
