using FerreteriaApi.DTOs.cellar_transfer;
using FerreteriaApi.DTOs.Responses;
using FerreteriaApi.Repository.CellarTransferRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaApi.Controllers
{
    [ApiController]
    [Route("api/cellarTrans")]
    public class CellarTransferController : ControllerBase
    {
        private readonly ICellarTransferRepository _cellarTransferRepository;

        public CellarTransferController(ICellarTransferRepository cellarTransferRepository)
        {
            this._cellarTransferRepository = cellarTransferRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CellarTransferDTO>> Get([FromRoute] int id)
        {
            try
            {
                var cellarTransfer = await _cellarTransferRepository.GetByIdAsync(id);

                if (cellarTransfer == null)
                {
                    return NotFound(new ErrorResponse($"The cellarTransfer id was not found."));
                }

                return Ok(cellarTransfer);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpGet("byNoTransfer/{noTransfer}")]
        public async Task<ActionResult<CellarTransferDTO>> Get([FromRoute] string noTransfer)
        {
            try
            {
                var cellarTransfer = await _cellarTransferRepository.GetByNoDocAsync(noTransfer);

                if (cellarTransfer == null)
                {
                    return NotFound(new ErrorResponse($"The No. Transfer was not found."));
                }

                return Ok(cellarTransfer);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<CellarTransferDTO>>> Get()
        {
            try
            {
                var cellarTransfers = await _cellarTransferRepository.GetAllAsync();

                return Ok(cellarTransfers);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }


        [HttpPost]
        public async Task<ActionResult> Create(CellarTransferCreateDTO cellarTransferCreateDTO)
        {
            try
            {
                var cellarTransfer = await _cellarTransferRepository.GetByNoDocAsync(cellarTransferCreateDTO.NoTransfer);

                if (cellarTransfer != null)
                {
                    return BadRequest(new ErrorResponse($"This No. Transfer has been already register."));
                }

                await _cellarTransferRepository.CreateAsync(cellarTransferCreateDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromBody] CellarTransferUpdateDTO cellarTransferUpdateDTO, [FromRoute] int id)
        {
            try
            {
                var cellarTransfer = await _cellarTransferRepository.GetByIdAsync(id);

                if (cellarTransfer == null)
                {
                    return NotFound(new ErrorResponse($"The cellarTransfer id was not found."));
                }

                await _cellarTransferRepository.UpdateAsync(cellarTransferUpdateDTO, id);
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
                var cellarTransfer = await _cellarTransferRepository.GetByIdAsync(id);

                if (cellarTransfer == null)
                {
                    return NotFound(new ErrorResponse($"The cellarTransfer id was not found."));
                }

                await _cellarTransferRepository.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }
    }
}
