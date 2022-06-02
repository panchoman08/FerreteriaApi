using FerreteriaApi.DTOs.supplier;

namespace FerreteriaApi.Repository.SupplierRepositories
{
    public interface ISupplierRepository
    {
        Task<SupplierDTO> GetByIdAsync(int id);
        Task<SupplierDTO> GetByNameAsync(string name);
        Task<SupplierDTO> GetByNitAsync(string name);
        Task<List<SupplierDTO>> GetAllAsync();
        Task<List<SupplierDTO>> GetAllThatContains(string name);
        Task CreateAsync(SupplierCreateDTO supplierStatus);
        Task UpdateAsync(SupplierUpdateDTO supplierStatus, int id);
        Task DeleteAsync(int id);
    }
}
