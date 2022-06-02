using AutoMapper;
using FerreteriaApi.DTOs.product;
using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaApi.Repository.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ferreteria_dbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ferreteria_dbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ProductDTO>(product);
        }
        public async Task<ProductDTO> GetByNameAsync(string name)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Name == name);
            return _mapper.Map<ProductDTO>(product);
        }
        public async Task<List<ProductDTO>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<List<ProductDTO>> GetAllThatContainsNameAsync(string productName)
        {
            var products = await _context.Products.Where(x => x.Name.Contains(productName)).ToListAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetBySkuAsync(string sku)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Sku == sku);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task CreateAsync(CreateProductDTO createProductDTO)
        {
            var product = _mapper.Map<Product>(createProductDTO);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductUpdateDTO productDTO, int id)
        {

            var productToUpdate = await _context.Products.SingleAsync(x => x.Id == id);

            productToUpdate.Sku = string.IsNullOrEmpty(productDTO.Sku) ? productToUpdate.Sku : productDTO.Sku;
            productToUpdate.Name = string.IsNullOrEmpty(productDTO.Name) ? productToUpdate.Name : productDTO.Name;
            productToUpdate.Description = string.IsNullOrEmpty(productDTO.Description) ? productToUpdate.Description : productDTO.Description;
            productToUpdate.BuyPrice = string.IsNullOrEmpty(productDTO.BuyPrice.ToString()) ? productToUpdate.BuyPrice : productDTO.BuyPrice;
            productToUpdate.Stock = string.IsNullOrEmpty(productDTO.Stock.ToString()) ? productToUpdate.Stock : productDTO.Stock;
            productToUpdate.CategoryId = string.IsNullOrEmpty(productDTO.CategoryId.ToString()) ? productToUpdate.CategoryId : productDTO.CategoryId;
            productToUpdate.MeasureId = string.IsNullOrEmpty(productDTO.MeasureId.ToString()) ? productToUpdate.MeasureId : productDTO.MeasureId;
            productToUpdate.StatusId = string.IsNullOrEmpty(productDTO.StatusId.ToString()) ? productToUpdate.StatusId : productDTO.StatusId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }
        
       

        
    }
}
