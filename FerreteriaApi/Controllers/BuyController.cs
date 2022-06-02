using FerreteriaApi.DTOs.buy;
using FerreteriaApi.DTOs.Responses;
using FerreteriaApi.Repository.BuyRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaApi.Controllers
{
    [ApiController]
    [Route("api/buy")]
    public class BuyController : ControllerBase
    {
        private readonly IBuyRepository _buyRepository;

        public BuyController(IBuyRepository buyRepository)
        {
            this._buyRepository = buyRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BuyDTO>> Get([FromRoute]  int id)
        {
            try
            {
                var buy = await _buyRepository.GetByIdAsync(id);

                if (buy == null)
                {
                    return NotFound(new ErrorResponse($"This buy id was not found."));
                }

                return Ok(buy);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<BuyDTO>> Get([FromRoute] string name)
        {
            try
            {
                var buy = await _buyRepository.GetByNameAsync(name);

                if (buy == null)
                {
                    return NotFound(new ErrorResponse($"This buy name was not found."));
                }

                return Ok(buy);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<BuyDTO>>> GetAll()
        {
            try
            {
                var buys = await _buyRepository.GetAllAsync();

                return Ok(buys);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpGet("contains/{name}")]
        public async Task<ActionResult<List<BuyDTO>>> GetAllThatContainsNameSupplier([FromRoute] string name)
        {
            try
            {
                var buys = await _buyRepository.GetAllThatContainsNameAsync(name);

                return Ok(buys);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] BuyCreateDTO buyCreateDTO)
        {
            try
            {
                await _buyRepository.CreateAsync(buyCreateDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] BuyUpdateDTO buyUpdateDTO)
        {
            try
            {
                var buyById = await _buyRepository.GetByIdAsync(id);

                if (buyById == null)
                {
                    return NotFound(new ErrorResponse($"The buy id was not found."));
                }
                await _buyRepository.UpdateAsync(buyUpdateDTO,  id);

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
                var buyById = await _buyRepository.GetByIdAsync(id);

                if(buyById == null) return NotFound(new ErrorResponse($"The buy id was not found.")); 

                await _buyRepository.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }
    }
}
