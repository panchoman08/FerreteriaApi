using AutoMapper;
using FerreteriaApi.DTOs.customer_category;
using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaApi.Repository.CustomerCatRepositories
{
    public class CustomerCatRepository : ICustomerCatRepository
    {
        private readonly ferreteria_dbContext _context;
        private readonly IMapper _mapper;

        public CustomerCatRepository(ferreteria_dbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<CustomerCatDTO> GetByIdAsync(int id)
        {
            var customerCat = await _context.CustomerCats.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<CustomerCatDTO>(customerCat);
        }

        public async Task<CustomerCatDTO> GetByNameAsync(string name)
        {
            var customerCat = await _context.CustomerCats.FirstOrDefaultAsync(x => x.Name == name);
            return _mapper.Map<CustomerCatDTO>(customerCat);
        }

        public async Task<List<CustomerCatDTO>> GetAllAsync()
        {
            var customerCats = await _context.CustomerCats.ToListAsync();
            return _mapper.Map<List<CustomerCatDTO>>(customerCats);
        }

        public async Task<List<CustomerCatDTO>> GetAllThatContains(string name)
        {
            var customerCats = await _context.CustomerCats.Where(x => x.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<CustomerCatDTO>>(customerCats);
        }

        public async Task CreateAsync(CustomerCatCreateDTO customerCatCreateDTO)
        {
            var customer = _mapper.Map<CustomerCat>(customerCatCreateDTO);
            _context.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CustomerCatUpdateDTO customerCatUpdateDTO, int id)
        {
            var customerCatToUpdate = await _context.CustomerCats.SingleAsync(x => x.Id == id);

            customerCatToUpdate.Name = (string.IsNullOrEmpty(customerCatUpdateDTO.Name)) ? customerCatToUpdate.Name : customerCatUpdateDTO.Name ;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var customerCat = await _context.CustomerCats.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(customerCat);
            await _context.SaveChangesAsync();
        }
    }
}
