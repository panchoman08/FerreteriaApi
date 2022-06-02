using FerreteriaApi.DTOs.customer_category;
using FerreteriaApi.DTOs.Responses;
using FerreteriaApi.Repository.CustomerCatRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaApi.Controllers
{
    [ApiController]
    [Route("api/customerCat")]
    public class CustomerCategoryController : ControllerBase
    {
        private readonly ICustomerCatRepository _customerCatRepository;

        public CustomerCategoryController(ICustomerCatRepository customerCatRepository)
        {
            this._customerCatRepository = customerCatRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CustomerCatDTO>> Get([FromRoute] int id)
        {
            try
            {
                var customerCat = await _customerCatRepository.GetByIdAsync(id);

                if (customerCat == null)
                {
                    return NotFound(new ErrorResponse($"The id customer category was not found."));
                }

                return Ok(customerCat);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CustomerCatDTO>> Get([FromRoute] string name)
        {
            try
            {
                var customerCat = await _customerCatRepository.GetByNameAsync(name);

                if (customerCat == null)
                {
                    return NotFound(new ErrorResponse($"The id name category was not found."));
                }

                return Ok(customerCat);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<CustomerCatDTO>>> GetAll()
        {
            try
            {
                var customerCats = await _customerCatRepository.GetAllAsync();

                return Ok(customerCats);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("contains/{name}")]
        public async Task<ActionResult<List<CustomerCatDTO>>> GetAllThatContainsName([FromRoute] string name)
        {
            try
            {
                var customerCats = await _customerCatRepository.GetAllThatContains(name);

                return Ok(customerCats);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CustomerCatCreateDTO customerCatCreateDTO)
        {
            try
            {
                var productCatByName = await _customerCatRepository.GetByNameAsync(customerCatCreateDTO.Name);
                
                if (productCatByName != null)
                {
                    return BadRequest(new ErrorResponse($"This customer category has been already register."));
                }

                await _customerCatRepository.CreateAsync(customerCatCreateDTO);
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromBody] CustomerCatUpdateDTO customerCatUpdateDTO, [FromRoute] int id)
        {
            try
            {
                var productCatById= await _customerCatRepository.GetByIdAsync(id);

                if (productCatById == null)
                {
                    return NotFound(new ErrorResponse($"The customer category was not found."));
                }

                await _customerCatRepository.UpdateAsync(customerCatUpdateDTO, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var productCatById = await _customerCatRepository.GetByIdAsync(id);

                if (productCatById == null)
                {
                    return NotFound(new ErrorResponse($"The customer category was not found."));
                }

                await _customerCatRepository.DeleteAsync( id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

    }
}
