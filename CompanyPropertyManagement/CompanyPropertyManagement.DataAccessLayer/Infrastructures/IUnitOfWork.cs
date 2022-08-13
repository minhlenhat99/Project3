using CompanyPropertyManagement.DataAccessLayer.IRepositories;

namespace CompanyPropertyManagement.DataAccessLayer.Infrastructures
{
    public interface IUnitOfWork
    {
        IBuRepository BuRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IInventoryRepository InventoryRepository { get; }
        IPropertyRepository PropertyRepository { get; }
        IAuthenticationRepository AuthenticationRepository { get; }
        void SaveChanges();
    }
}
