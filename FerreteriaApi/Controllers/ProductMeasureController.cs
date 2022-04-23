using FerreteriaApi.DTOs.product_measure;
using FerreteriaApi.DTOs.Responses;
using FerreteriaApi.Repository.ProductMeasureRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaApi.Controllers
{
    [ApiController]
    [Route("api/productMeasure")]
    public class ProductMeasureController : ControllerBase
    {
        private readonly IProductMeasureRepository _productMeasureRepository;

        public ProductMeasureController(IProductMeasureRepository productMeasureRepository)
        {
            this._productMeasureRepository = productMeasureRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductMeasureDTO>> Get([FromRoute]int id)
        {
            try 
            {
                var measure = await _productMeasureRepository.GetByIdAsync(id);

                if (measure == null)
                {
                    return BadRequest(new ErrorResponse($"The id {id} was not found."));
                }

                return Ok(measure);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ProductMeasureDTO>> Get([FromRoute] string name)
        {
            try
            {
                var measure = await _productMeasureRepository.GetByNameAsync(name);

                if (measure ==  null)
                {
                    return BadRequest(new ErrorResponse($"The name {name} measure was not found."));
                }

                return Ok(measure);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ProductMeasureDTO>>> GetAll()
        {
            try
            {
                var measures = await _productMeasureRepository.GetAllAsync();
                return Ok(measures);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("contains/{name}")]
        public async Task<ActionResult<List<ProductMeasureDTO>>> GetAllThatContainsName([FromRoute] string name)
        {
            try
            {
                var measures = await _productMeasureRepository.GetAllThatContainsName(name);
                return Ok(measures);
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ProductMeasureCreateDTO productMeasureCreateDTO)
        {
            try
            {
                var measures = await _productMeasureRepository.GetByNameAsync(productMeasureCreateDTO.Name);
                
                if(measures != null)
                {
                    return BadRequest(new ErrorResponse($"This measure is already register"));
                }

                await _productMeasureRepository.CreateAsync(productMeasureCreateDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromBody] ProductMeasureUpdateDTO productMeasureUpdateDTO, [FromRoute] int id)
        {
            try
            {
                var measures = await _productMeasureRepository.GetByIdAsync(id);

                if (measures == null)
                {
                    return NotFound(new ErrorResponse($"The measure id: {id} was not found."));
                }

                await _productMeasureRepository.UpdateAsync(productMeasureUpdateDTO, id);

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
                var measureById = await _productMeasureRepository.GetByIdAsync(id);

                if (measureById == null)
                {
                    return NotFound(new ErrorResponse($"The measure id: {id} was not found."));
                }

                await _productMeasureRepository.DeleteAsync(id);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

    }
}
