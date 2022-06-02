using FerreteriaApi.DTOs.customer_category;

namespace FerreteriaApi.Repository.CustomerCatRepositories
{
    public interface ICustomerCatRepository
    {
        Task<CustomerCatDTO> GetByIdAsync(int id);
        Task<CustomerCatDTO> GetByNameAsync(string name);
        Task<List<CustomerCatDTO>> GetAllAsync();
        Task<List<CustomerCatDTO>> GetAllThatContains(string name);
        Task CreateAsync(CustomerCatCreateDTO supplierStatus);
        Task UpdateAsync(CustomerCatUpdateDTO supplierStatus, int id);
        Task DeleteAsync(int id);
    }
}
