using FerreteriaApi.DTOs.buy_details;
using FerreteriaApi.DTOs.Responses;
using FerreteriaApi.Repository.BuyDetailRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaApi.Controllers
{
    [ApiController]
    [Route("api/buyDetail")]
    public class BuyDetailController : ControllerBase
    {
        private readonly IBuyDetailRepository _buyDetailRepository;

        public BuyDetailController(IBuyDetailRepository buyDetailRepository)
        {
            this._buyDetailRepository = buyDetailRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<BuyDetailDTO>>> GetAllThatContainIdBuy([FromRoute]int id)
        {
            try
            {
                var detailsByBuyId = await _buyDetailRepository.GetAllThatContainsBuyId(id);

                return Ok(detailsByBuyId);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] BuyDetailCreateDTO buyDetailCreateDTO)
        {
            try
            {
                var exist = await _buyDetailRepository.HasAlreadyRegister(buyDetailCreateDTO.Id, buyDetailCreateDTO.IdProduct);

                if (exist) return BadRequest($"This product has been already register in this detail.");

                await _buyDetailRepository.CreateAsync(buyDetailCreateDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n{ex.InnerException}"));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromBody] BuyDetailUpdateDTO buyDetailUpdateDTO, [FromRoute] int id)
        {
            try
            {
                var exist = await _buyDetailRepository.HasAlreadyRegister(id, buyDetailUpdateDTO.IdProduct);

                if (!exist) BadRequest($"This product don't exist in this detail.");

                await _buyDetailRepository.UpdateAsync(buyDetailUpdateDTO, id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpDelete("{idBuy:int}/{idProduct:int}")]
        public async Task<ActionResult> Delete([FromRoute] int idBuy, [FromRoute] int idProduct)
        {
            try
            {
                Console.WriteLine($"idBuy: {idBuy} idProduct: {idProduct}");
                var existDetail = await _buyDetailRepository.HasAlreadyRegister(idBuy, idProduct);

                if (!existDetail)
                {
                    return NotFound(new ErrorResponse($"The idBuy and idProduct were not found"));
                }

                await _buyDetailRepository.DeleteAsync(idBuy, idProduct);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

    }
}
