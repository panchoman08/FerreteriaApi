using FerreteriaApi.DTOs.product_status;
using FerreteriaApi.DTOs.Responses;
using FerreteriaApi.Repository.ProductStatusRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaApi.Controllers
{
    [ApiController]
    [Route("api/productStatus")]
    public class ProductStatusController : ControllerBase
    {
        private readonly IProductStatusRepository _productStatusRepository;

        public ProductStatusController(IProductStatusRepository productStatusRepository)
        {
            this._productStatusRepository = productStatusRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ProductStatusDTO>>> Get()
        {
            try
            {
                return await _productStatusRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductStatusDTO>> Get([FromRoute] int id)
        {
            try
            {
                var productStatusById = await _productStatusRepository.GetByIdAsync(id);

                if (productStatusById == null)
                {
                    return NotFound(new ErrorResponse($"IdStatus: {id} was not found."));
                }

                return Ok(productStatusById);

            }catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ProductStatusDTO>> Get([FromRoute] string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name)) return BadRequest(new ErrorResponse("The name must not be null or empty."));

                var productStatusByName = await _productStatusRepository.GetByNameAsync(name);

                if (productStatusByName == null)
                {
                    return NotFound(new ErrorResponse($"The product status was not found."));
                }

                return Ok(productStatusByName);
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("contains/{name}")]
        public async Task<ActionResult<List<ProductStatusDTO>>> GetAllThatContains([FromRoute] string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name)) return BadRequest(new ErrorResponse("The name must not be null or empty."));

                var productsStatus = await _productStatusRepository.GetAllThatContains(name);

                return Ok(productsStatus);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ProductStatusCreateDTO productStatusCreateDTO)
        {
            try
            {
                var producsStatusByName = await _productStatusRepository.GetByNameAsync(productStatusCreateDTO.Name);

                if (producsStatusByName != null)
                {
                    return BadRequest(new ErrorResponse($"This product status has been alrady register."));
                }

                await _productStatusRepository.CreateAsync(productStatusCreateDTO);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromBody] ProductStatusUpdateDTO productStatusDTO, [FromRoute]int id)
        {
            try
            {
                var productStatus = await _productStatusRepository.GetByIdAsync(id);
                if (productStatus == null)
                {
                    return NotFound(new ErrorResponse($"ProductStatus id: {id} was not found"));
                }

                await _productStatusRepository.UpdateAsync(productStatusDTO, id);

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
                var productStatusById = await _productStatusRepository.GetByIdAsync(id);

                if (productStatusById == null)
                {
                    return NotFound(new ErrorResponse($"ProductStatus id: {id} was not found"));
                }

                await _productStatusRepository.DeleteAsync(id);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

    }
}
