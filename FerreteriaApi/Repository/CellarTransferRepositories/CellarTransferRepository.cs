using AutoMapper;
using FerreteriaApi.DTOs.cellar_transfer;
using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaApi.Repository.CellarTransferRepositories
{

    public interface ICellarTransferRepository : ICRUDsBaseRepository<CellarTransferDTO, CellarTransferCreateDTO, CellarTransferUpdateDTO>
    {
        Task<CellarTransferDTO> GetByNoDocAsync(string noDoc);
    }

    public class CellarTransferRepository : ICellarTransferRepository
    {
        private readonly ferreteria_dbContext _context;
        private readonly IMapper _mapper;

        public CellarTransferRepository(ferreteria_dbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
       
        public async Task<CellarTransferDTO> GetByIdAsync(int id)
        {
            var cellar = await _context.CellarTransfers.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<CellarTransferDTO>(cellar);
        }

        public async Task<CellarTransferDTO> GetByNoDocAsync(string noDoc)
        {
            var cellarTransfer = await _context.CellarTransfers.FirstOrDefaultAsync(x => x.NoTransfer == noDoc);
            return _mapper.Map<CellarTransferDTO>(cellarTransfer);
        }
        public async Task<List<CellarTransferDTO>> GetAllAsync()
        {
            var cellartransfers = await _context.CellarTransfers.ToListAsync();
            return _mapper.Map<List<CellarTransferDTO>>(cellartransfers);
        }

        public async Task CreateAsync(CellarTransferCreateDTO cellarTransferCreateDTO)
        {
            var newCellar = _mapper.Map<CellarTransfer>(cellarTransferCreateDTO);
            _context.Add(newCellar);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(CellarTransferUpdateDTO cellarTransUpdateDTO, int id)
        {
            var cellarTransToUpdate = await _context.CellarTransfers.SingleAsync(x => x.Id == id);
            cellarTransToUpdate.NoTransfer = string.IsNullOrEmpty(cellarTransUpdateDTO.NoTransfer.ToString()) ? cellarTransToUpdate.NoTransfer : cellarTransUpdateDTO.NoTransfer;
            cellarTransToUpdate.CellarOriginId = string.IsNullOrEmpty(cellarTransUpdateDTO.CellarOriginId.ToString()) ? cellarTransToUpdate.CellarOriginId : cellarTransUpdateDTO.CellarOriginId;
            cellarTransToUpdate.CellarDestinationId = string.IsNullOrEmpty(cellarTransUpdateDTO.CellarDestinationId.ToString()) ? cellarTransToUpdate.CellarDestinationId : cellarTransUpdateDTO.CellarDestinationId;
            cellarTransToUpdate.Date = string.IsNullOrEmpty(cellarTransUpdateDTO.Date.ToString()) ? cellarTransToUpdate.Date : cellarTransUpdateDTO.Date;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cellarTransToDelete = await _context.CellarTransfers.SingleAsync(x => x.Id == id);
            _context.Remove(cellarTransToDelete);
            await _context.SaveChangesAsync();
        }

        public Task<CellarTransferDTO> GetByNameAsync(string name) => throw new NotImplementedException();

        public Task<List<CellarTransferDTO>> GetAllThatContainsNameAsync(string name) => throw new NotImplementedException();
    }
}
