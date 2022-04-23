using FerreteriaApi.DTOs.product;

namespace FerreteriaApi.Repository.ProductRepositories
{
    public interface IProductRepository
    {
        Task<ProductDTO> GetByIdAsync(int id);
        Task<ProductDTO> GetBySkuAsync(string sku);
        Task<ProductDTO> GetByNameAsync(string name);
        Task<List<ProductDTO>> GetAllAsync();
        Task<List<ProductDTO>> GetAllThatContainsNameAsync(string productName);
        Task CreateAsync(CreateProductDTO product);
        Task DeleteAsync(int id);
        Task UpdateAsync(ProductUpdateDTO product, int id);
    }
}
