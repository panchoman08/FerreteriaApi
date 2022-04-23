using AutoMapper;
using FerreteriaApi.DTOs.supplier_category;
using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaApi.Repository.SupplierCatRepositories
{
    public class SupplierCatRepository : ISupplierCatRepository
    {
        private readonly ferreteria_dbContext _context;
        private readonly IMapper _mapper;

        public SupplierCatRepository(ferreteria_dbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<SupplierCatDTO> GetByIdAsync(int id)
        {
            var suplierCat = await _context.SupplierCats.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<SupplierCatDTO>(suplierCat);
        }

        public async Task<SupplierCatDTO> GetByNameAsync(string name)
        {
            var suplierCat = await _context.SupplierCats.FirstOrDefaultAsync(x => x.Name == name);
            return _mapper.Map<SupplierCatDTO>(suplierCat);
        }
        public async Task<List<SupplierCatDTO>> GetAllAsync()
        {
            var suplierCat = await _context.SupplierCats.ToListAsync();
            return _mapper.Map<List<SupplierCatDTO>>(suplierCat);
        }
        public async Task<List<SupplierCatDTO>> GetAllThatContains(string name)
        {
            var suplierCat = await _context.SupplierCats.Where(x => x.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<SupplierCatDTO>>(suplierCat); ;
        }

        public async Task CreateAsync(SupplierCatCreateDTO supplierCatCreateDTO)
        {
            var suplierCat = _mapper.Map<SupplierCat>(supplierCatCreateDTO);
            _context.SupplierCats.Add(suplierCat);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SupplierCatUpdateDTO supplierStatus, int id)
        {
            var suplierCatToUpdate = await _context.SupplierCats.SingleAsync(x => x.Id == id);
            suplierCatToUpdate.Name = (String.IsNullOrEmpty(supplierStatus.Name)) ? suplierCatToUpdate.Name : supplierStatus.Name;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var supplierCatToDelete = await _context.SupplierCats.SingleAsync(x => x.Id == id);
            _context.Remove(supplierCatToDelete);
            await _context.SaveChangesAsync();
        }
        
    }
}
