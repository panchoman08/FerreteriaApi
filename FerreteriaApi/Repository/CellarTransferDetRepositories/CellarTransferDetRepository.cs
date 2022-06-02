using AutoMapper;
using FerreteriaApi.DTOs.cellar_transfer_details;
using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaApi.Repository.CellarTransferDetRepositories
{
    public interface ICellarTransferDetRepository : ICRUDsBaseRepository<CellarTransferDetDTO, CellarTransDetCreateDTO, CellarTransDetUpdateDTO>
    {
        Task<List<CellarTransferDetDTO>> GetAllByNoTransferAsync(string noTransfer);
        Task<List<CellarTransferDetDTO>> GetAllByTransferId(int id);
    }
    public class CellarTransferDetRepository : ICellarTransferDetRepository
    {
        private readonly ferreteria_dbContext _context;
        private readonly IMapper _mapper;

        public CellarTransferDetRepository(ferreteria_dbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<CellarTransferDetDTO> GetByIdAsync(int id)
        {
            var cellarTransDet = await _context.CellarTransferDets.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<CellarTransferDetDTO>(cellarTransDet);
        }

        public async Task<List<CellarTransferDetDTO>> GetAllByNoTransferAsync(string noTransfer)
        {
            //var cellarTransfer = await _context.CellarTransfers.Where(x => x.NoTransfer == noTransfer).ToListAsync();
            //return _mapper.Map<List<CellarTransferDetDTO>>(cellarTransfer);
            throw new NotImplementedException();
        }
        
        public async Task<List<CellarTransferDetDTO>> GetAllAsync()
        {
            var cellarTransDet = await _context.CellarTransferDets.ToListAsync();
            return _mapper.Map<List<CellarTransferDetDTO>>(cellarTransDet);
        }

        public async Task<List<CellarTransferDetDTO>> GetAllByTransferId(int id)
        {
            var cellarTransDet = await _context.CellarTransferDets.Where(x => x.CellarTransId == id).ToListAsync();
            return _mapper.Map<List<CellarTransferDetDTO>>(cellarTransDet);
        }

        public async Task CreateAsync(CellarTransDetCreateDTO cellarCreateDTO)
        {
            var newCellarTransDet = _mapper.Map<CellarTransferDet>(cellarCreateDTO);
            _context.Add(newCellarTransDet);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(CellarTransDetUpdateDTO cellarTransDetUpdateDTO, int id)
        {
            var cellarTransDetToUpdate = await _context.CellarTransferDets.SingleAsync(x => x.Id == id);

            cellarTransDetToUpdate.ProductId = string.IsNullOrEmpty(cellarTransDetUpdateDTO.ProductId.ToString()) ? cellarTransDetToUpdate.ProductId : cellarTransDetUpdateDTO.ProductId;
            cellarTransDetToUpdate.Units = string.IsNullOrEmpty(cellarTransDetUpdateDTO.Units.ToString()) ? cellarTransDetToUpdate.Units : cellarTransDetUpdateDTO.Units;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cellarTransDetToDelete = await _context.CellarTransferDets.SingleAsync(x => x.Id == id);
            _context.Remove(cellarTransDetToDelete);
            await _context.SaveChangesAsync();
        }

        public Task<CellarTransferDetDTO> GetByNameAsync(string name) => throw new NotImplementedException();
        public Task<List<CellarTransferDetDTO>> GetAllThatContainsNameAsync(string name) => throw new NotImplementedException();

        
    }
}
