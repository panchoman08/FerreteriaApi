using FerreteriaApi.DTOs.product_category;

namespace FerreteriaApi.Repository.ProductCatRepositories
{
    public interface IProductCatRepository
    {
        Task<ProductCategoryDTO> GetByIdAsync(int id);
        Task<ProductCategoryDTO> GetByNameAsync(string name);
        Task<List<ProductCategoryDTO>> GetAllAsync();
        Task<List<ProductCategoryDTO>> GetAllThatContainsNameAsync(string productName);
        Task CreateAsync(ProductCategoryCreateDTO createProductCategoryDTO);
        Task UpdateAsync(ProductCategoryUpdateDTO createProductCategoryDTO, int id);
        Task DeleteAsync(int id);
    }
}
