using CompanyPropertyManagement.Data.Context;
using CompanyPropertyManagement.Data.Domain;
using CompanyPropertyManagement.DataAccessLayer.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CompanyPropertyManagement.DataAccessLayer.Repositories
{
    public class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(ApplicationDbContext context) : base(context)
        {
        }
        public override IQueryable<Inventory> FindAll() => _dbSet.Include(i => i.BU).Include(i => i.User);
        public override IQueryable<Inventory> FindAllByCondition(Expression<Func<Inventory, bool>> expression)
            => _dbSet.Where(expression).Include(i => i.BU).Include(i => i.User);
    }
}
