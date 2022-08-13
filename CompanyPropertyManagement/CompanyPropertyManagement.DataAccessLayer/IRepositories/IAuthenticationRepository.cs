using CompanyPropertyManagement.DTOs.Authentication;
using System.Threading.Tasks;

namespace CompanyPropertyManagement.DataAccessLayer.IRepositories
{
    public interface IAuthenticationRepository
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
    }
}
