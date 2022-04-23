using AutoMapper;
using FerreteriaApi.DTOs.product_measure;
using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaApi.Repository.ProductMeasureRepositories
{
    public class ProductMeasureRepository : IProductMeasureRepository
    {
        private readonly ferreteria_dbContext _context;
        private readonly IMapper _mapper;

        public ProductMeasureRepository(ferreteria_dbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ProductMeasureDTO> GetByIdAsync(int id)
        {
            var productMeasures = await _context.Measures.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ProductMeasureDTO>(productMeasures);
        }

        public async Task<ProductMeasureDTO> GetByNameAsync(string name)
        {
            var productMeasures = await _context.Measures.FirstOrDefaultAsync(x => x.Name == name);
            return _mapper.Map<ProductMeasureDTO>(productMeasures);
        } 
        public async Task<List<ProductMeasureDTO>> GetAllAsync()
        {
            var productMeasures = await _context.Measures.ToListAsync();
            return _mapper.Map<List<ProductMeasureDTO>>(productMeasures);
        }

        public async Task<List<ProductMeasureDTO>> GetAllThatContainsName(string name)
        {
            var productMeasures = await _context.Measures.Where(x => x.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<ProductMeasureDTO>>(productMeasures);
        }

        public async Task CreateAsync(ProductMeasureCreateDTO productMeasureCreateDTO)
        {
            var productMeasure = _mapper.Map<Measure>(productMeasureCreateDTO);
            _context.Measures.Add(productMeasure);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductMeasureUpdateDTO productMeasureDTO, int id)
        {
            var measureToUpdate = await _context.Measures.SingleAsync(x => x.Id == id);

            measureToUpdate.Name = string.IsNullOrEmpty(productMeasureDTO.Name) ? measureToUpdate.Name : productMeasureDTO.Name;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var measureToDelete = _context.Measures.SingleOrDefault(x => x.Id == id);

            _context.Remove(measureToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
