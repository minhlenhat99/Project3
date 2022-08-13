using CompanyPropertyManagement.Data.Context;
using CompanyPropertyManagement.Data.Domain;
using CompanyPropertyManagement.DataAccessLayer.IRepositories;

namespace CompanyPropertyManagement.DataAccessLayer.Repositories
{
    public class BuRepository : BaseRepository<BU>, IBuRepository
    {
        public BuRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
