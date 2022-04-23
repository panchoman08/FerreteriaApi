using FerreteriaApi.DTOs.product_measure;

namespace FerreteriaApi.Repository.ProductMeasureRepositories
{
    public interface IProductMeasureRepository
    {
        Task<ProductMeasureDTO> GetByIdAsync(int id);
        Task<ProductMeasureDTO> GetByNameAsync(string name);
        Task<List<ProductMeasureDTO>> GetAllAsync();
        Task<List<ProductMeasureDTO>> GetAllThatContainsName(string name);
        Task CreateAsync(ProductMeasureCreateDTO productMeasureDTO);
        Task UpdateAsync(ProductMeasureUpdateDTO productMeasureDTO, int id);
        Task DeleteAsync(int id);
    }
}
