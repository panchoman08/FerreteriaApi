using FerreteriaApi.DTOs.Responses;
using FerreteriaApi.DTOs.sale;
using FerreteriaApi.Repository.SaleRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaApi.Controllers
{
    [ApiController]
    [Route("api/sale")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;

        public SaleController(ISaleRepository saleRepository)
        {
            this._saleRepository = saleRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SaleDTO>> Get([FromRoute] int id)
        {
            try
            {
                var sale = _saleRepository.GetByIdAsync(id);

                if (sale == null)
                {
                    return NotFound(new ErrorResponse($"The sales id was not found."));
                }

                return Ok(sale);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet]
        public async Task<ActionResult<SaleDTO>> GetAll()
        {
            try
            {
                var sale = _saleRepository.GetAllAsync();

                return Ok(sale);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("byCustomerNit/{nit}")]
        public async Task<ActionResult<SaleDTO>> GetByCustomerNit([FromBody] string nit)
        {
            try
            {
                var sale = await _saleRepository.GetAllByCustomerNitAsync(nit);

                return Ok(sale);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("byCustomerName/{name}")]
        public async Task<ActionResult<SaleDTO>> GetByCustomerName([FromRoute] string name)
        {
            try
            {
                var sale = await _saleRepository.GetAllByCustomerNameAsync(name);

                return Ok(sale);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("byUserSys/{name}")]
        public async Task<ActionResult<SaleDTO>> GetByUserSys([FromRoute] string name)
        {
            try
            {
                var sale = _saleRepository.GetAllByUserSysNameAsync(name);

                return Ok(sale);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

    }
}
