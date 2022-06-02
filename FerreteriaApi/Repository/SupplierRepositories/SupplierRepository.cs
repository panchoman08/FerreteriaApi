using AutoMapper;
using FerreteriaApi.DTOs.supplier;
using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaApi.Repository.SupplierRepositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ferreteria_dbContext _context;
        private readonly IMapper _mapper;

        public SupplierRepository(ferreteria_dbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<SupplierDTO> GetByIdAsync(int id)
        {
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(x => x.Id == id);  
            return _mapper.Map<SupplierDTO>(supplier);
        }
        public async Task<SupplierDTO> GetByNameAsync(string name)
        {
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(x => x.Name == name);
            return _mapper.Map<SupplierDTO>(supplier);
        }
        public async Task<SupplierDTO> GetByNitAsync(string nit)
        {
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(x => x.Nit == nit);
            return _mapper.Map<SupplierDTO>(supplier);
        }
        public async Task<List<SupplierDTO>> GetAllAsync()
        {
            var suppliers = await _context.Suppliers.ToListAsync();
            return _mapper.Map<List<SupplierDTO>>(suppliers);
        }
        public async Task<List<SupplierDTO>> GetAllThatContains(string name)
        {
            var suppliers = await _context.Suppliers.Where(x => x.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<SupplierDTO>>(suppliers);
        }
        public async Task CreateAsync(SupplierCreateDTO supplierCreateDTO)
        {
            var supplier = _mapper.Map<Supplier>(supplierCreateDTO);
            _context.Add(supplier);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(SupplierUpdateDTO supplier, int id)
        {
            var supplierToUpdate = await _context.Suppliers.SingleAsync(x => x.Id == id);

            supplierToUpdate.Nit = (string.IsNullOrEmpty(supplier.Nit)) ? supplierToUpdate.Nit: supplier.Nit;
            supplierToUpdate.Name = (string.IsNullOrEmpty(supplier.Name)) ? supplierToUpdate.Name: supplier.Name;
            supplierToUpdate.Address = (string.IsNullOrEmpty(supplier.Address)) ? supplierToUpdate.Address : supplier.Address;
            supplierToUpdate.Phone = (string.IsNullOrEmpty(supplier.Phone)) ? supplierToUpdate.Phone: supplier.Phone;
            supplierToUpdate.CategoryId = (string.IsNullOrEmpty(supplier.CategoryId.ToString())) ? supplierToUpdate.CategoryId: supplier.CategoryId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var supplier = await _context.Suppliers.SingleAsync(x => x.Id == id);

            _context.Remove(supplier);
            await _context.SaveChangesAsync();
        }
    }
}
