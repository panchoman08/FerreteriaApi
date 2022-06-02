using AutoMapper;
using FerreteriaApi.DTOs.transaction_status;
using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaApi.Repository.TransactionStatusRepositories
{


    public interface ITransactionStatusRepository : ICRUDsBaseRepository<TransStatusDTO, TransStatusCreateDTO, TransStatusUpdateDTO>
    {

    }

    public class TransactionStatusRepository : ITransactionStatusRepository
    {
        private readonly ferreteria_dbContext _context;
        private readonly IMapper _mapper;

        public TransactionStatusRepository(ferreteria_dbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<TransStatusDTO> GetByIdAsync(int id)
        {
            var transStatus = await _context.TranStatuses.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<TransStatusDTO>(transStatus);
        }

        public async Task<TransStatusDTO> GetByNameAsync(string name)
        {
            var transStatus = await _context.TranStatuses.FirstOrDefaultAsync(x => x.Description == name);
            return _mapper.Map<TransStatusDTO>(transStatus);
        }

        public async Task<List<TransStatusDTO>> GetAllAsync()
        {
            var transStatus = await _context.TranStatuses.ToListAsync();
            return _mapper.Map<List<TransStatusDTO>>(transStatus);
        }

        public async Task<List<TransStatusDTO>> GetAllThatContainsNameAsync(string name)
        {
            var transStatus = await _context.TranStatuses.Where(x => x.Description.Contains(name)).ToListAsync();
            return _mapper.Map<List<TransStatusDTO>>(transStatus);
        }
        public async Task CreateAsync(TransStatusCreateDTO transStatusCreateDTO)
        {
            var transStatus = _mapper.Map<TranStatus>(transStatusCreateDTO);
            _context.Add(transStatus);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TransStatusUpdateDTO transStatusUpdateDTO, int id)
        {
            var transStatusToUpdate = await _context.TranStatuses.SingleAsync(x => x.Id == id);

            transStatusToUpdate.Description = (string.IsNullOrEmpty(transStatusUpdateDTO.Description)) ? transStatusToUpdate.Description : transStatusUpdateDTO.Description;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var transStatusToDelete = await _context.TranStatuses.FirstOrDefaultAsync(x => x.Id == id);

            _context.Remove(transStatusToDelete);
            await _context.SaveChangesAsync();
        }
        
    }
}
