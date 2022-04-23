using FerreteriaApi.DTOs.supplier_category;

namespace FerreteriaApi.Repository.SupplierCatRepositories
{
    public interface ISupplierCatRepository
    {
        Task<SupplierCatDTO> GetByIdAsync(int id);
        Task<SupplierCatDTO> GetByNameAsync(string name);
        Task<List<SupplierCatDTO>> GetAllAsync();
        Task<List<SupplierCatDTO>> GetAllThatContains(string name);
        Task CreateAsync(SupplierCatCreateDTO supplierStatus);
        Task UpdateAsync(SupplierCatUpdateDTO supplierStatus, int id);
        Task DeleteAsync(int id);
    }
}
