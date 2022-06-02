using FerreteriaApi.DTOs.customer;
using FerreteriaApi.DTOs.Responses;
using FerreteriaApi.Repository.CustomerRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaApi.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var customerById= await _customerRepository.GetByIdAsync(id);

                if (customerById == null)
                {
                    return NotFound(new ErrorResponse($"The customer id was not found."));
                }

                return Ok(customerById);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"{ex.Message}"));
            }
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get([FromRoute] string name)
        {
            try
            {
                var customerByName = await _customerRepository.GetByNameAsync(name);

                if (customerByName == null)
                {
                    return NotFound(new ErrorResponse($"The customer name was not found."));
                }

                return Ok(customerByName);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"{ex.Message}"));
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var customers = await _customerRepository.GetAllAsync();

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"{ex.Message}"));
            }
        }

        [HttpGet("contains/{name}")]
        public async Task<IActionResult> GetAll([FromRoute] string name)
        {
            try
            {
                var customers = await _customerRepository.GetAllThatContainsNameAsync(name);

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"{ex.Message}"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CustomerCreateDTO customerCreateDTO)
        {
            try
            {
                var customerByNit = await _customerRepository.GetByNitAsync(customerCreateDTO.Nit);
                var customerByName = await _customerRepository.GetByNameAsync(customerCreateDTO.Name);

                if (customerByNit != null && customerByName != null)
                {
                    return BadRequest(new ErrorResponse($"This Customer has already been register."));
                }

                await _customerRepository.CreateAsync(customerCreateDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"{ex.Message}"));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromBody] CustomerUpdateDTO customerUpdateDTO, [FromRoute] int id)
        {
            try
            {
                var customerById = await _customerRepository.GetByIdAsync(id);

                if (customerById == null)
                {
                    return NotFound(new ErrorResponse($"The customer id was not found."));
                }

                await _customerRepository.UpdateAsync(customerUpdateDTO, id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"{ex.Message}\n {ex.InnerException}"));
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var customerById = await _customerRepository.GetByIdAsync(id);

                if (customerById == null)
                {
                    return NotFound(new ErrorResponse($"The customer id was not found."));
                }

                await _customerRepository.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"{ex.Message}"));
            }
        }


    }
}
