using AutoMapper;
using FerreteriaApi.DTOs;
using FerreteriaApi.DTOs.user_sys;
using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaApi.Repository.AuthenticateRepositories
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly ferreteria_dbContext _context;
        private readonly IMapper _mapper;

        public AuthenticateRepository(ferreteria_dbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public Task Create(UserRegister userRegister)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseAuthentication> GetByUsername(string username)
        {
            var user = await _context.UserSys.FirstOrDefaultAsync(x => x.Username == username);
            return _mapper.Map<ResponseAuthentication>(user);
        }

        public async Task<ResponseAuthentication> GetByUsernameAndPassword(string username, string password)
        {
            var user = await _context.UserSys.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
            return _mapper.Map<ResponseAuthentication>(user);
        }
    }
}
