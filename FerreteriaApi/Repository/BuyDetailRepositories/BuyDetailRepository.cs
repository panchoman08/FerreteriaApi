using AutoMapper;
using FerreteriaApi.DTOs.buy_details;
using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaApi.Repository.BuyDetailRepositories
{

    public interface IBuyDetailRepository : ICRUDsBaseRepository<BuyDetailDTO, BuyDetailCreateDTO, BuyDetailUpdateDTO>
    {
        Task<List<BuyDetailDTO>> GetAllThatContainsBuyId(int id);

        Task<bool> HasAlreadyRegister(int id, int idProduct);

        Task DeleteAsync(int id, int idProduct);
    }

    public class BuyDetailRepository : IBuyDetailRepository
    {
        private readonly ferreteria_dbContext _context;
        private readonly IMapper _mapper;

        public BuyDetailRepository(ferreteria_dbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<BuyDetailDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BuyDetailDTO>> GetAllThatContainsBuyId(int id)
        {
            //var buyDetails = await _context.BuyDets.Where(x => x.Id.ToString().Contains(id.ToString())).ToListAsync();
            //var buyDetails = await _context.BuyDets.Include(x => x.IdProductNavigation).Where(x => x.Id == id).ToListAsync();
            //return _mapper.Map<List<BuyDetailDTO>>(buyDetails);
            throw new NotImplementedException();
        }
        public Task<BuyDetailDTO> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BuyDetailDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<BuyDetailDTO>> GetAllThatContainsNameAsync(string productName)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(BuyDetailCreateDTO buyDetailCreateDTO)
        {
            var buyDetail = _mapper.Map<BuyDet>(buyDetailCreateDTO);
            _context.Add(buyDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BuyDetailUpdateDTO buyDetailUpdateteDTO, int id)
        {
            var buyDetailToUpdate = await _context.BuyDets.SingleAsync(x => x.Id == id);

            buyDetailToUpdate.ProductId = string.IsNullOrEmpty(buyDetailUpdateteDTO.IdProduct.ToString()) ? buyDetailToUpdate.ProductId : buyDetailUpdateteDTO.IdProduct;
            buyDetailToUpdate.Price = string.IsNullOrEmpty(buyDetailUpdateteDTO.Price.ToString()) ? buyDetailToUpdate.Price : buyDetailUpdateteDTO.Price;
            buyDetailToUpdate.Units = string.IsNullOrEmpty(buyDetailUpdateteDTO.Units.ToString()) ? buyDetailToUpdate.Units : buyDetailUpdateteDTO.Units;
            buyDetailToUpdate.Discount = string.IsNullOrEmpty(buyDetailUpdateteDTO.Discount.ToString()) ? buyDetailToUpdate.Discount : buyDetailUpdateteDTO.Discount;
            buyDetailToUpdate.SubTotal = string.IsNullOrEmpty(buyDetailUpdateteDTO.SubTotal.ToString()) ? buyDetailToUpdate.SubTotal : buyDetailUpdateteDTO.SubTotal;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id, int idProduct)
        {
            var buyDetailToDelete = await _context.BuyDets.SingleOrDefaultAsync(x => x.Id == id && x.ProductId == idProduct);
            _context.Remove(buyDetailToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> HasAlreadyRegister(int id, int idProduct)
        {
            var buyDetailByProductId = await _context.BuyDets.FirstOrDefaultAsync(x => x.Id == id && x.ProductId == idProduct);

            return (buyDetailByProductId != null) ? true : false;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
