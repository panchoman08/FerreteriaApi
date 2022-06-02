using AutoMapper;
using FerreteriaApi.DTOs.inventory;
using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaApi.Repository.InventoryRepositories
{

    public interface IInventoryRepository : ICRUDsBaseRepository<InventoryDTO, InventoryCreateDTO, InventoryUpdateDTO>
    {
        Task<List<InventoryDTO>> GetByProductId(int id);
    }

    public class InventoryRepository : IInventoryRepository
    {
        private readonly ferreteria_dbContext _context;
        private readonly IMapper _mapper;

        public InventoryRepository(ferreteria_dbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        

        public async Task<InventoryDTO> GetByIdAsync(int id)
        {
            var inventaryById = await _context.Inventories.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<InventoryDTO>(inventaryById);
        }

        public async Task<List<InventoryDTO>> GetAllAsync()
        {
            var inventory = await _context.Inventories.ToListAsync();
            return _mapper.Map<List<InventoryDTO>>(inventory);
        }

        public async Task<List<InventoryDTO>> GetByProductId(int id)
        {
            var inventoryByProductId = await _context.Inventories.Where(x => x.ProductId == id).ToListAsync();
            return _mapper.Map<List<InventoryDTO>>(inventoryByProductId);
        }

        public async Task CreateAsync(InventoryCreateDTO inventoryCreataDTO)
        {
            var inventory = _mapper.Map<Inventory>(inventoryCreataDTO);
            _context.Add(inventory);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(InventoryUpdateDTO inventoryUpdateDTO, int id)
        {
            var inventoryToUpdate = await _context.Inventories.SingleOrDefaultAsync(x => x.Id == id);

            inventoryToUpdate.ProductId = (string.IsNullOrEmpty(inventoryUpdateDTO.ProductId.ToString())) ? inventoryToUpdate.ProductId : inventoryUpdateDTO.ProductId;
            inventoryToUpdate.CellarId = (string.IsNullOrEmpty(inventoryUpdateDTO.CellarId.ToString())) ? inventoryToUpdate.CellarId : inventoryUpdateDTO.CellarId;
            inventoryToUpdate.BuyId = (string.IsNullOrEmpty(inventoryUpdateDTO.BuyId.ToString())) ? inventoryToUpdate.BuyId : inventoryUpdateDTO.BuyId;
            inventoryToUpdate.SaleId = (string.IsNullOrEmpty(inventoryUpdateDTO.SaleId.ToString())) ? inventoryToUpdate.SaleId : inventoryUpdateDTO.SaleId;
            inventoryToUpdate.CellarTransId = (string.IsNullOrEmpty(inventoryUpdateDTO.CellarTransId.ToString())) ? inventoryToUpdate.CellarTransId : inventoryUpdateDTO.CellarTransId;
            inventoryToUpdate.Units = (string.IsNullOrEmpty(inventoryUpdateDTO.Units.ToString())) ? inventoryToUpdate.Units : inventoryUpdateDTO.Units;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var inventoryToDelete = await _context.Inventories.SingleOrDefaultAsync(x => x.Id == id);
            _context.Remove(inventoryToDelete);
            await _context.SaveChangesAsync();
        }

        public Task<List<InventoryDTO>> GetAllThatContainsNameAsync(string name) => throw new NotImplementedException();

        public Task<InventoryDTO> GetByNameAsync(string name) => throw new NotImplementedException();

    }
}
