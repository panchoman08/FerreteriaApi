using AutoMapper;
using FerreteriaApi.DTOs.buy;
using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaApi.Repository.BuyRepositories
{

    public interface IBuyRepository : ICRUDsBaseRepository<BuyDTO, BuyCreateDTO, BuyUpdateDTO> 
    {
        
    }


    public class BuyRepository : IBuyRepository
    {
        private readonly ferreteria_dbContext _context;
        private readonly IMapper _mapper;

        public BuyRepository(ferreteria_dbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<BuyDTO> GetByIdAsync(int id)
        {
            var buyById = await _context.Buys.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<BuyDTO>(buyById);
        }

        public Task<BuyDTO> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
        public async Task<List<BuyDTO>> GetAllAsync()
        {
            var buys = await _context.Buys.ToListAsync();
            return _mapper.Map<List<BuyDTO>>(buys);
        }

        public async Task<List<BuyDTO>> GetAllThatContainsNameAsync(string nameSupplier)
        {
            //var buys = await _context.Buys.Include(x => x..Name.Contains(nameSupplier)).ToListAsync();
            //return _mapper.Map<List<BuyDTO>>(buys);
            throw new NotImplementedException();
        }
        public async Task CreateAsync(BuyCreateDTO buyCreateDTO)
        {
            var buy = _mapper.Map<Buy>(buyCreateDTO);
            _context.Add(buy);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(BuyUpdateDTO buyUpdateDTO, int id)
        {
            var buyToUpdate = await _context.Buys.SingleAsync(x => x.Id == id);
            buyToUpdate.SupplierId = string.IsNullOrEmpty(buyUpdateDTO.IdSupplier.ToString()) ? buyToUpdate.SupplierId : buyUpdateDTO.IdSupplier;
            buyToUpdate.UserId = string.IsNullOrEmpty(buyUpdateDTO.IdUser.ToString()) ? buyToUpdate.UserId : buyUpdateDTO.IdUser;
            buyToUpdate.Date = string.IsNullOrEmpty(buyUpdateDTO.Date.ToString()) ? buyToUpdate.Date : buyUpdateDTO.Date;
            buyToUpdate.Total = string.IsNullOrEmpty(buyUpdateDTO.Total.ToString()) ? buyToUpdate.Total : buyUpdateDTO.Total;
        }

        public async Task DeleteAsync(int id)
        {
            var rowsAffected = await _context.Database.ExecuteSqlRawAsync($"EXEC buy_delete_register {id}");
            Console.WriteLine($"Row Affected: {rowsAffected}");
        }
        
    }
}
