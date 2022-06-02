using FerreteriaApi.DTOs.Responses;
using FerreteriaApi.DTOs.supplier;
using FerreteriaApi.Repository.SupplierRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaApi.Controllers
{
    [ApiController]
    [Route("api/supplier")]
    public class SupplierController : ControllerBase
    {
        
        private readonly ISupplierRepository _supplierRepository;

        public SupplierController(ISupplierRepository supplierRepository)
        {
            this._supplierRepository = supplierRepository;
        }
    
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SupplierDTO>> Get([FromRoute] int id)
        {
            try
            {
                var supplier = await _supplierRepository.GetByIdAsync(id);
                
                if (supplier == null)
                {
                    return NotFound(new ErrorResponse($"The id supplier was not found."));
                }

                return Ok(supplier);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }
        
        [HttpGet("{name}")]
        public async Task<ActionResult<SupplierDTO>> Get([FromRoute] string name)
        {
            try
            {
                var supplier = await _supplierRepository.GetByNameAsync(name);

                if (supplier == null)
                {
                    return NotFound(new ErrorResponse($"The name supplier was not found."));
                }

                return Ok(supplier);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }
        
        [HttpGet("all")]
        public async Task<ActionResult<List<SupplierDTO>>> Get()
        {
            try
            {
                var suppliers = await _supplierRepository.GetAllAsync();
                return Ok(suppliers);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }
        
        [HttpGet("contains/{name}")]
        public async Task<ActionResult<List<SupplierDTO>>> GetAllThatContainsName([FromRoute] string name)
        {
            try
            {
                var suppliers = await _supplierRepository.GetAllThatContains(name);
                return Ok(suppliers);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<List<SupplierDTO>>> Create([FromBody] SupplierCreateDTO supplierCreateDTO)
        {
            try
            {
                var supplierById = await _supplierRepository.GetByNitAsync(supplierCreateDTO.Nit);

                if (supplierById != null)
                {
                    return BadRequest(new ErrorResponse($"The nit supplier is already register."));
                }

                await _supplierRepository.CreateAsync(supplierCreateDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n{ex.InnerException}"));
            }
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromBody] SupplierUpdateDTO supplierUpdateDTO, [FromRoute] int id)
        {
            try
            {
                var supplierById = await _supplierRepository.GetByIdAsync(id);

                if (supplierById == null)
                {
                    return NotFound(new ErrorResponse($"The id Supplier was not found."));
                }

                await _supplierRepository.UpdateAsync(supplierUpdateDTO, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }
        

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var supplierById = await _supplierRepository.GetByIdAsync(id);

                if (supplierById == null)
                {
                    return NotFound(new ErrorResponse($"The id Supplier was not found."));
                }

                await _supplierRepository.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }
    }
}
