using CompanyPropertyManagement.Data.Context;
using CompanyPropertyManagement.Data.Domain;
using CompanyPropertyManagement.DataAccessLayer.IRepositories;
using CompanyPropertyManagement.DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace CompanyPropertyManagement.DataAccessLayer.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private IBuRepository _buRepository;
        private ICategoryRepository _categoryRepository;
        private IInventoryRepository _inventoryRepository;
        private IPropertyRepository _propertyRepository;
        private IAuthenticationRepository _authenticationRepository;
        public UnitOfWork(ApplicationDbContext context, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }
        public IBuRepository BuRepository 
        { 
            get 
            {   
                if(_buRepository == null)
                {
                    _buRepository = new BuRepository(_context);
                }
                return _buRepository;
            } 
        }
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_context);
                }
                return _categoryRepository;
            }
        }
        public IInventoryRepository InventoryRepository
        {
            get
            {
                if (_inventoryRepository == null)
                {
                    _inventoryRepository = new InventoryRepository(_context);
                }
                return _inventoryRepository;
            }
        }
        public IPropertyRepository PropertyRepository
        {
            get
            {
                if (_propertyRepository == null)
                {
                    _propertyRepository = new PropertyRepository(_context);
                }
                return _propertyRepository;
            }
        }

        public IAuthenticationRepository AuthenticationRepository
        {
            get
            {
                if(_authenticationRepository == null)
                {
                    _authenticationRepository = new AuthenticationRepository(_userManager, _configuration);
                }
                return _authenticationRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
