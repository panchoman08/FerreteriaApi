using FerreteriaApi.DTOs.Responses;
using FerreteriaApi.DTOs.transaction_status;
using FerreteriaApi.Repository.TransactionStatusRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaApi.Controllers
{

    [ApiController]
    [Route("api/transStatus")]
    public class TransStatusController : ControllerBase
    {
        private readonly ITransactionStatusRepository _transactionStatusRepository;

        public TransStatusController(ITransactionStatusRepository transactionStatusRepository)
        {
            this._transactionStatusRepository = transactionStatusRepository;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<TransStatusDTO>> Get([FromRoute] int id)
        {
            try
            {
                var transStatusById = await _transactionStatusRepository.GetByIdAsync(id);

                if (transStatusById == null)
                {
                    return NotFound(new ErrorResponse("The id transStatus was not found."));
                }

                return Ok(transStatusById); 
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<TransStatusDTO>> Get([FromRoute] string name)
        {
            try
            {
                var transStatusByName = await _transactionStatusRepository.GetByNameAsync(name);

                if (transStatusByName == null)
                {
                    return NotFound(new ErrorResponse("The transStatus name was not found."));
                }

                return Ok(transStatusByName);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<TransStatusDTO>> GetAll()
        {
            try
            {
                var transStatus = await _transactionStatusRepository.GetAllAsync();

                return Ok(transStatus);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("contains/{name}")]
        public async Task<ActionResult<TransStatusDTO>> GetAllThatContainsName([FromRoute] string name)
        {
            try
            {
                var transStatus = await _transactionStatusRepository.GetAllThatContainsNameAsync(name);

                return Ok(transStatus);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TransStatusCreateDTO transStatusCreateDTO)
        {
            try
            {
                var transStatus = await _transactionStatusRepository.GetByNameAsync(transStatusCreateDTO.Description);

                if (transStatus != null) return BadRequest(new ErrorResponse("This transStatus has been already register."));

                await _transactionStatusRepository.CreateAsync(transStatusCreateDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] TransStatusUpdateDTO transStatusUpdateDTO)
        {
            try
            {
                var transStatus = await _transactionStatusRepository.GetByIdAsync(id);

                if (transStatus == null) return NotFound(new ErrorResponse("This transStatus id was not found."));

                await _transactionStatusRepository.UpdateAsync(transStatusUpdateDTO, id);

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
                var transactionStatus = await _transactionStatusRepository.GetByIdAsync(id);

                if (transactionStatus == null) return NotFound(new ErrorResponse("This trans Status waas not found."));

                await _transactionStatusRepository.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

    }
}
