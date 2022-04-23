using AutoMapper;
using FerreteriaApi.DTOs.product_category;
using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaApi.Repository.ProductCatRepositories
{
    public class ProductCatRepository : IProductCatRepository
    {
        private readonly ferreteria_dbContext _context;
        private readonly IMapper _mapper;

        public ProductCatRepository(ferreteria_dbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ProductCategoryDTO> GetByIdAsync(int id)
        {
            var productCat = await _context.ProductCats.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ProductCategoryDTO>(productCat);
        }

        public async Task<ProductCategoryDTO> GetByNameAsync(string name)
        {
            var productCat = await _context.ProductCats.FirstOrDefaultAsync(x => x.Name == name);
            return _mapper.Map<ProductCategoryDTO>(productCat);
        }

        public async Task<List<ProductCategoryDTO>> GetAllAsync()
        {
            var productCat = await _context.ProductCats.ToListAsync();
            return _mapper.Map<List<ProductCategoryDTO>>(productCat);
        }

        public async Task<List<ProductCategoryDTO>> GetAllThatContainsNameAsync(string productName)
        {
            var productsCat = await _context.ProductCats.Where(x => x.Name.Contains(productName)).ToListAsync();
            return _mapper.Map<List<ProductCategoryDTO>>(productsCat);
        }

        public async Task CreateAsync(ProductCategoryCreateDTO productCategoryCreateDTO)
        {
            var productCatDTO = _mapper.Map<ProductCat>(productCategoryCreateDTO);
            _context.ProductCats.Add(productCatDTO);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductCategoryUpdateDTO productCategoryUpdateDTO, int id)
        {
            var catToUpdate = await _context.ProductCats.SingleAsync(x => x.Id == id);
            catToUpdate.Name = String.IsNullOrEmpty(productCategoryUpdateDTO.Name) ? catToUpdate.Name : productCategoryUpdateDTO.Name;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var productCatToDetele = await _context.ProductCats.FirstOrDefaultAsync(x => x.Id == id);
            _context.ProductCats.Remove(productCatToDetele);
            await _context.SaveChangesAsync();
        }   
    }
}
