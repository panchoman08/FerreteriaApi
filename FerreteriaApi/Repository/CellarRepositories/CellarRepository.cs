using AutoMapper;
using FerreteriaApi.DTOs.cellar;
using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaApi.Repository.CellarRepositories
{

    public interface ICellarRepository : ICRUDsBaseRepository<CellarDTO, CellarCreateDTO, CellarUpdateDTO>
    {

    }


    public class CellarRepository : ICellarRepository
    {
        private readonly ferreteria_dbContext _context;
        private readonly IMapper _mapper;

        public CellarRepository(ferreteria_dbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<CellarDTO> GetByIdAsync(int id)
        {
            var cellar = await _context.Cellars.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<CellarDTO>(cellar);
        }

        public async Task<CellarDTO> GetByNameAsync(string name)
        {
            var cellar = await _context.Cellars.FirstOrDefaultAsync(x => x.Name == name);
            return _mapper.Map<CellarDTO>(cellar);
        }
        public async Task<List<CellarDTO>> GetAllAsync()
        {
            var cellars = await _context.Cellars.ToListAsync();
            return _mapper.Map<List<CellarDTO>>(cellars);
        }

        public async Task<List<CellarDTO>> GetAllThatContainsNameAsync(string name)
        {
            var cellars = await _context.Cellars.Where(x => x.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<CellarDTO>>(cellars);
        }
        public async Task CreateAsync(CellarCreateDTO cellarCreateDTO)
        {
            var newCellar = _mapper.Map<Cellar>(cellarCreateDTO);
            _context.Add(newCellar);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(CellarUpdateDTO cellarUpdateDTO, int id)
        {
            var cellarToUpdate = await _context.Cellars.SingleAsync(x => x.Id == id);
            cellarToUpdate.Name = string.IsNullOrEmpty(cellarUpdateDTO.Name) ? cellarToUpdate.Name : cellarUpdateDTO.Name;
            cellarToUpdate.Address = string.IsNullOrEmpty(cellarUpdateDTO.Address) ? cellarToUpdate.Address : cellarUpdateDTO.Address;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cellarToDelete = await _context.Cellars.SingleAsync(x => x.Id == id);
            _context.Remove(cellarToDelete);
            await _context.SaveChangesAsync();
        }
        
    }
}
