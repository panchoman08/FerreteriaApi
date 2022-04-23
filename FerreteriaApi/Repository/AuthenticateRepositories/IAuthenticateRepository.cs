using FerreteriaApi.DTOs;
using FerreteriaApi.DTOs.user_sys;

namespace FerreteriaApi.Repository.AuthenticateRepositories
{
    public interface IAuthenticateRepository
    {
        Task Create(UserRegister userRegister);
        Task<ResponseAuthentication> GetByUsername(string username);

        Task<ResponseAuthentication> GetByUsernameAndPassword(string username, string password);
    }
}
