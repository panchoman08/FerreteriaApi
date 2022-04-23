using FerreteriaApi.DTOs.product_status;

namespace FerreteriaApi.Repository.ProductStatusRepositories
{
    public interface IProductStatusRepository
    {
        Task<ProductStatusDTO> GetByIdAsync(int id);
        Task<ProductStatusDTO> GetByNameAsync(string name);
        Task<List<ProductStatusDTO>> GetAllAsync();
        Task<List<ProductStatusDTO>> GetAllThatContains(string name);
        Task CreateAsync(ProductStatusCreateDTO productStatusDTO);
        Task UpdateAsync(ProductStatusUpdateDTO productStatusDTO, int id);
        Task DeleteAsync(int id);
    }

}
