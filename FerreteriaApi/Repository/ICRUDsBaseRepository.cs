namespace FerreteriaApi.Repository
{
    public interface ICRUDsBaseRepository<T1,T2,T3>
    {
        Task<T1> GetByIdAsync(int id);
        Task<T1> GetByNameAsync(string name);
        Task<List<T1>> GetAllAsync();
        Task<List<T1>> GetAllThatContainsNameAsync(string name);
        Task CreateAsync(T2 dto);
        Task UpdateAsync(T3 dto, int id);
        Task DeleteAsync(int id);
    }
}
