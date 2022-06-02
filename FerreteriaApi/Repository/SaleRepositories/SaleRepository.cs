using AutoMapper;
using FerreteriaApi.DTOs.sale;
using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaApi.Repository.SaleRepositories
{

    public interface ISaleRepository : ICRUDsBaseRepository<SaleDTO, SaleCreateDTO, SaleUpdateDTO>
    {
        Task<List<SaleDTO>> GetAllByCustomerNameAsync(string name);
        Task<List<SaleDTO>> GetAllByCustomerNitAsync(string name);
        Task<List<SaleDTO>> GetAllByUserSysNameAsync(string name);
    }
    public class SaleRepository : ISaleRepository
    {
        private readonly ferreteria_dbContext _context;
        private readonly IMapper _mapper;

        public SaleRepository(ferreteria_dbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<SaleDTO> GetByIdAsync(int id)
        {
            var sale = await _context.Sales.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<SaleDTO>(sale);
        }

        public Task<SaleDTO> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SaleDTO>> GetAllAsync()
        {
            var sales = await _context.Sales.ToListAsync();
            return _mapper.Map<List<SaleDTO>>(sales);
        }
        public async Task<List<SaleDTO>> GetAllByCustomerNameAsync(string name)
        {
            //var sales = await _context.Sales.Where(x => x.IdCustomerNavigation.Name == name).ToListAsync();
            //return _mapper.Map<List<SaleDTO>>(sales);
            throw new NotImplementedException();
        }

        public async Task<List<SaleDTO>> GetAllByCustomerNitAsync(string nit)
        {
            //var sales = await _context.Sales.Where(x => x.IdCustomerNavigation.Nit == nit).ToListAsync();
            //return _mapper.Map<List<SaleDTO>>(sales);
            throw new NotImplementedException();
        }

        public async Task<List<SaleDTO>> GetAllByUserSysNameAsync(string username)
        {
            //var sales = await _context.Sales.Where(x => x.IdUserNavigation.Username == username).Take(3).ToListAsync();
            //return _mapper.Map<List<SaleDTO>>(sales);
            throw new NotImplementedException();
        }

        public Task<List<SaleDTO>> GetAllThatContainsNameAsync(string name)
        {
            throw new NotImplementedException();
        }
        public async Task CreateAsync(SaleCreateDTO saleCreateDTO)
        {
            var sale = _mapper.Map<Sale>(saleCreateDTO);
            _context.Add(sale);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SaleUpdateDTO saleUpdateDTO, int id)
        {
            var saleToUpdate = await _context.Sales.SingleAsync(x => x.Id == id);

            saleToUpdate.CustomerId = (string.IsNullOrEmpty(saleUpdateDTO.CustomerId.ToString())) ? saleToUpdate.CustomerId : saleUpdateDTO.CustomerId;
            saleToUpdate.UserId = (string.IsNullOrEmpty(saleUpdateDTO.UserId.ToString())) ? saleToUpdate.UserId : saleUpdateDTO.UserId;
            saleToUpdate.TranStatusId = (string.IsNullOrEmpty(saleUpdateDTO.TranStatusId.ToString())) ? saleToUpdate.TranStatusId : saleUpdateDTO.TranStatusId;
            saleToUpdate.Date = (string.IsNullOrEmpty(saleUpdateDTO.Date.ToString())) ? saleToUpdate.Date : saleUpdateDTO.Date;
            saleToUpdate.Total = (string.IsNullOrEmpty(saleUpdateDTO.Total.ToString())) ? saleToUpdate.Total : saleUpdateDTO.Total;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var saleToDelete = await _context.Sales.SingleAsync(x => x.Id == id);

            _context.Remove(saleToDelete);
            await _context.SaveChangesAsync();
        }

    }
}
