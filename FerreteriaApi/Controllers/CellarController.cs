using FerreteriaApi.DTOs.cellar;
using FerreteriaApi.DTOs.Responses;
using FerreteriaApi.Repository.CellarRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaApi.Controllers
{
    [ApiController]
    [Route("api/cellar")]
    public class CellarController : ControllerBase
    {
        private readonly ICellarRepository _cellarRepository;

        public CellarController(ICellarRepository cellarRepository)
        {
            this._cellarRepository = cellarRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CellarDTO>> Get([FromRoute] int id)
        {
            try
            {
                var cellarById = await _cellarRepository.GetByIdAsync(id);

                if (cellarById == null)
                {
                    return NotFound(new ErrorResponse($"The cellar id was not found."));
                }

                return Ok(cellarById);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CellarDTO>> Get([FromRoute] string name)
        {
            try
            {
                var cellarByName = await _cellarRepository.GetByNameAsync(name);

                if (cellarByName == null)
                {
                    return NotFound(new ErrorResponse($"The cellar name was not found."));
                }

                return Ok(cellarByName);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<CellarDTO>>> Get()
        {
            try
            {
                var cellars = await _cellarRepository.GetAllAsync();

                return Ok(cellars);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpGet("contains/{name}")]
        public async Task<ActionResult<List<CellarDTO>>> GetAllThatContains([FromRoute] string name)
        {
            try
            {
                var cellars = await _cellarRepository.GetAllThatContainsNameAsync(name);

                return Ok(cellars);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpPost]
        public async Task<ActionResult<CellarCreateDTO>> Create(CellarCreateDTO cellarCreateDTO)
        {
            try
            {
                var cellar = await _cellarRepository.GetByNameAsync(cellarCreateDTO.Name);

                if (cellar != null)
                {
                    return BadRequest(new ErrorResponse($"This cellar has been already register."));
                }

                await _cellarRepository.CreateAsync(cellarCreateDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromBody] CellarUpdateDTO cellarUpdateDTO, [FromRoute] int id)
        {
            try
            {
                var cellar = await _cellarRepository.GetByIdAsync(id);

                if (cellar == null)
                {
                    return NotFound(new ErrorResponse($"The cellar id was not found."));
                }

                await _cellarRepository.UpdateAsync(cellarUpdateDTO, id);
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
                var cellar = await _cellarRepository.GetByIdAsync(id);

                if (cellar == null)
                {
                    return NotFound(new ErrorResponse($"The cellar id was not found."));
                }

                await _cellarRepository.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

    }
}
