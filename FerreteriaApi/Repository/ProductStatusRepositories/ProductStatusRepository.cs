using AutoMapper;
using FerreteriaApi.DTOs.product_status;
using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaApi.Repository.ProductStatusRepositories
{
    public class ProductStatusRepository : IProductStatusRepository
    {
        private readonly ferreteria_dbContext _context;
        private readonly IMapper _mapper;

        public ProductStatusRepository(ferreteria_dbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }


        public async Task<ProductStatusDTO> GetByIdAsync(int id)
        {
            var productStatusById = await _context.ProductSta.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ProductStatusDTO>(productStatusById);
        }

        public async Task<ProductStatusDTO> GetByNameAsync(string name)
        {
            var productStatusByName = await _context.ProductSta.FirstOrDefaultAsync(x => x.Name == name);
            return _mapper.Map<ProductStatusDTO>(productStatusByName);
        }

        public async Task<List<ProductStatusDTO>> GetAllAsync()
        {
            var productsStatus = await _context.ProductSta.ToListAsync();
            return _mapper.Map<List<ProductStatusDTO>>(productsStatus);
        }

        public async Task<List<ProductStatusDTO>> GetAllThatContains(string name)
        {
            var productsStatus = await _context.ProductSta.Where(x => x.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<ProductStatusDTO>>(productsStatus);
        }

        public async Task CreateAsync(ProductStatusCreateDTO product)
        {
            var productSta = _mapper.Map<ProductStum>(product);
            _context.ProductSta.Add(productSta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductStatusUpdateDTO product, int id)
        {
            var statusToUpdate = await  _context.ProductSta.SingleAsync(x => x.Id == id);
            statusToUpdate.Name = (String.IsNullOrEmpty(product.Name)) ? statusToUpdate.Name : product.Name;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productToDelete = await _context.ProductSta.SingleAsync(x => x.Id == id);
            _context.Remove(productToDelete);
            await _context.SaveChangesAsync();
        }

        
    }
}
