using FerreteriaApi.DTOs.Responses;
using FerreteriaApi.DTOs.supplier_category;
using FerreteriaApi.Repository.SupplierCatRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaApi.Controllers
{
    [ApiController]
    [Route("api/supplierCat")]
    public class SupplierCategoryController : ControllerBase
    {
        private readonly ISupplierCatRepository _supplierCatRepository;

        public SupplierCategoryController(ISupplierCatRepository supplierCatRepository)
        {
            this._supplierCatRepository = supplierCatRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SupplierCatDTO>> Get([FromRoute] int id)
        {
            try
            {
                var supplierCat = await _supplierCatRepository.GetByIdAsync(id);

                if (supplierCat == null)
                {
                    return NotFound(new ErrorResponse($"The supplierCategory was not found."));
                }
                return Ok(supplierCat);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<SupplierCatDTO>> Get([FromRoute] string name)
        {
            try
            {
                var supplierCat = await _supplierCatRepository.GetByNameAsync(name);

                if (supplierCat == null)
                {
                    return NotFound(new ErrorResponse($"The supplierCategory was not found."));
                }

                return Ok(supplierCat);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<SupplierCatDTO>>> Get()
        {
            try
            {
                var suppliersCat = await _supplierCatRepository.GetAllAsync();
                return Ok(suppliersCat);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("contains/{name}")]
        public async Task<ActionResult<List<SupplierCatDTO>>> GetAllThatContainsName([FromRoute] string name)
        {
            try
            {
                var suppliersCat = await _supplierCatRepository.GetAllThatContains(name);
                return Ok(suppliersCat);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] SupplierCatCreateDTO supplierCatCreateDTO)
        {
            try
            {
                var suppliersCat = await _supplierCatRepository.GetByNameAsync(supplierCatCreateDTO.Name);

                if (suppliersCat != null)
                {
                    return BadRequest(new ErrorResponse($"The supplier category is already register."));
                }

                await _supplierCatRepository.CreateAsync(supplierCatCreateDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromBody] SupplierCatUpdateDTO supplierCatUpdateDTO, [FromRoute] int id)
        {
            try
            {
                var suppliersCat = await _supplierCatRepository.GetByIdAsync(id);

                if (suppliersCat == null)
                {
                    return NotFound(new ErrorResponse($"The supplierCategory was not found."));
                }

                await _supplierCatRepository.UpdateAsync(supplierCatUpdateDTO, id);

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
                var supplierCat = await _supplierCatRepository.GetByIdAsync(id);

                if (supplierCat == null)
                {
                    return NotFound(new ErrorResponse($"The supplierCategory was not found."));
                }

                await _supplierCatRepository.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }
    }
}
