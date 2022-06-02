using AutoMapper;
using FerreteriaApi.DTOs.user_sys_category;
using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaApi.Repository.UserSysCatRepositories
{

    public interface IUserSysCatRepository : ICRUDsBaseRepository<UserRolDTO, UserRolCreateDTO, UserRolUpdateDTO> { }

    public class UserRolRepository : IUserSysCatRepository
    {
        private readonly ferreteria_dbContext _context;
        private readonly IMapper _mapper;

        public UserRolRepository(ferreteria_dbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<UserRolDTO> GetByIdAsync(int id)
        {
            var rolById = await _context.RolUsers.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<UserRolDTO>(rolById);
        }

        public async Task<UserRolDTO> GetByNameAsync(string name)
        {
            var rolByName = await _context.RolUsers.FirstOrDefaultAsync(x => x.Name == name);
            return _mapper.Map<UserRolDTO>(rolByName);
        }

        public async Task<List<UserRolDTO>> GetAllAsync()
        {
            var roles = await _context.RolUsers.ToListAsync();
            return _mapper.Map<List<UserRolDTO>>(roles);
        }

        public async Task<List<UserRolDTO>> GetAllThatContainsNameAsync(string productName)
        {
            var roles = await _context.RolUsers.Where(x => x.Name.Contains(productName)).ToListAsync();
            return _mapper.Map<List<UserRolDTO>>(roles);
        }
        public async Task CreateAsync(UserRolCreateDTO userRolCreateDTO)
        {
            var rol = _mapper.Map<RolUser>(userRolCreateDTO);
            _context.Add(rol);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateAsync(UserRolUpdateDTO userRolUpdateDTO, int id)
        {
            var rolToUpdate = await _context.RolUsers.SingleAsync(x => x.Id == id);
            rolToUpdate.Name = string.IsNullOrEmpty(userRolUpdateDTO.Name) ? rolToUpdate.Name : userRolUpdateDTO.Name;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var rolToDelete = await _context.RolUsers.SingleAsync(x => x.Id == id);

            _context.Remove(rolToDelete);
            await _context.SaveChangesAsync();
        }
    }
    
}
