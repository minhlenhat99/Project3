using CompanyPropertyManagement.Data.Context;
using CompanyPropertyManagement.Data.Domain;
using CompanyPropertyManagement.DataAccessLayer.IRepositories;

namespace CompanyPropertyManagement.DataAccessLayer.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
