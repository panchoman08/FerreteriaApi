using AutoMapper;
using FerreteriaApi.DTOs.customer;
using FerreteriaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaApi.Repository.CustomerRepositories
{
    public interface ICustomerRepository : ICRUDsBaseRepository<CustomerDTO, CustomerCreateDTO, CustomerUpdateDTO>
    {
        Task<CustomerDTO> GetByNitAsync(string nit);
    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ferreteria_dbContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(ferreteria_dbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<CustomerDTO> GetByIdAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<CustomerDTO> GetByNameAsync(string name)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Name == name);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<CustomerDTO> GetByNitAsync(string nit)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Nit == nit);
            return _mapper.Map<CustomerDTO>(customer);
        }
        public async Task<List<CustomerDTO>> GetAllAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            return _mapper.Map<List<CustomerDTO>>(customers);
        }

        public async Task<List<CustomerDTO>> GetAllThatContainsNameAsync(string productName)
        {
            var customers = await _context.Customers.Where(x => x.Name.Contains(productName)).ToListAsync();
            return _mapper.Map<List<CustomerDTO>>(customers);
        }

        public async Task CreateAsync(CustomerCreateDTO customerCreateDTO)
        {
            var customer = _mapper.Map<Customer>(customerCreateDTO);
            _context.Add(customer);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(CustomerUpdateDTO customerUpdateDTO, int id)
        {
            var customerToUpdate = await _context.Customers.SingleAsync(x => x.Id == id);

            customerToUpdate.Nit = (string.IsNullOrEmpty(customerUpdateDTO.Nit)) ? customerToUpdate.Nit : customerUpdateDTO.Nit; 
            customerToUpdate.Name = (string.IsNullOrEmpty(customerUpdateDTO.Name)) ? customerToUpdate.Name : customerUpdateDTO.Name; 
            customerToUpdate.Address = (string.IsNullOrEmpty(customerUpdateDTO.Address)) ? customerToUpdate.Address : customerUpdateDTO.Address; 
            customerToUpdate.Phone = (string.IsNullOrEmpty(customerUpdateDTO.Phone)) ? customerToUpdate.Phone : customerUpdateDTO.Phone; 
            customerToUpdate.CategoryId = (string.IsNullOrEmpty(customerUpdateDTO.CategoryId.ToString())) ? customerToUpdate.CategoryId : customerUpdateDTO.CategoryId; 

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.SingleAsync(x => x.Id == id);
            _context.Remove(customer);
            await _context.SaveChangesAsync();
        }

        
    }
}
