using FerreteriaApi.DTOs.cellar_transfer_details;
using FerreteriaApi.DTOs.Responses;
using FerreteriaApi.Repository.CellarTransferDetRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaApi.Controllers
{
    [ApiController]
    [Route("api/cellarTransDet")]
    public class CellarTransferDetController : ControllerBase
    {
        private readonly ICellarTransferDetRepository _cellarTransferDetRepository;

        public CellarTransferDetController(ICellarTransferDetRepository cellarTransferDetRepository)
        {
            this._cellarTransferDetRepository = cellarTransferDetRepository;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<CellarTransferDetDTO>> Get([FromRoute] int id)
        {
            try
            {
                var cellarTransfersDet = await _cellarTransferDetRepository.GetByIdAsync(id);

                if (cellarTransfersDet == null)
                {
                    return NotFound(new ErrorResponse($"The cellarTransferDet id was not found."));
                }

                return Ok(cellarTransfersDet);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpGet("allByTransId/{id:int}")]
        public async Task<ActionResult<List<CellarTransferDetDTO>>> GetAllByTransferId([FromRoute] int id)
        {
            try
            {
                var cellarTransfersDet = await _cellarTransferDetRepository.GetAllByTransferId(id);

                return Ok(cellarTransfersDet);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpGet("byNoTransfer/{noTransfer}")]
        public async Task<ActionResult<List<CellarTransferDetDTO>>> Get([FromRoute] string noTransfer)
        {
            try
            {
                var cellarTransfersDet = await _cellarTransferDetRepository.GetAllByNoTransferAsync(noTransfer);

                if (cellarTransfersDet == null)
                {
                    return NotFound(new ErrorResponse($"The No. TransferDet was not found."));
                }

                return Ok(cellarTransfersDet);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<CellarTransferDetDTO>>> Get()
        {
            try
            {
                var cellarTransfersDet = await _cellarTransferDetRepository.GetAllAsync();

                return Ok(cellarTransfersDet);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }


        [HttpPost]
        public async Task<ActionResult> Create(CellarTransDetCreateDTO cellarTransDetCreateDTO)
        {
            try
            {
                /*var cellarTransfer = await _cellarTransferDetRepository.GetByNoDocAsync(cellarTransferCreateDTO.NoTransfer);

                if (cellarTransfer != null)
                {
                    return BadRequest(new ErrorResponse($"This No. Transfer has been already register."));
                }*/

                await _cellarTransferDetRepository.CreateAsync(cellarTransDetCreateDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromBody] CellarTransDetUpdateDTO cellarTransDetUpdateDTO, [FromRoute] int id)
        {
            try
            {
                var cellarTransfer = await _cellarTransferDetRepository.GetByIdAsync(id);

                if (cellarTransfer == null)
                {
                    return NotFound(new ErrorResponse($"The cellarTransferDet id was not found."));
                }

                await _cellarTransferDetRepository.UpdateAsync(cellarTransDetUpdateDTO, id);
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
                var cellarTransfer = await _cellarTransferDetRepository.GetByIdAsync(id);

                if (cellarTransfer == null)
                {
                    return NotFound(new ErrorResponse($"The cellarTransferDet id was not found."));
                }

                await _cellarTransferDetRepository.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }
    }
}
