using FerreteriaApi.DTOs.inventory;
using FerreteriaApi.DTOs.Responses;
using FerreteriaApi.Repository.InventoryRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaApi.Controllers
{
    [ApiController]
    [Route("api/inventory")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryController(IInventoryRepository inventoryRepository)
        {
            this._inventoryRepository = inventoryRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<InventoryDTO>> Get([FromRoute] int id)
        {
            try
            {
                var inventoryById = await _inventoryRepository.GetByIdAsync(id);

                if (inventoryById == null)
                {
                    return NotFound(new ErrorResponse($"The inventory id was not found."));
                }

                return Ok(inventoryById);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<InventoryDTO>> GetAll()
        {
            try
            {
                var inventory = await _inventoryRepository.GetAllAsync();

                return Ok(inventory);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpGet("byProductId/{id:int}")]
        public async Task<ActionResult<InventoryDTO>> GetByProductId([FromRoute] int id)
        {
            try
            {
                var inventory = await _inventoryRepository.GetByProductId(id);

                return Ok(inventory);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(InventoryCreateDTO inventoryCreateDTO)
        {
            try
            {
                await _inventoryRepository.CreateAsync(inventoryCreateDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromBody] InventoryUpdateDTO inventoryUpdateDTO, [FromRoute] int id)
        {
            try
            {
                var inventory = await _inventoryRepository.GetByIdAsync(id);

                if (inventory == null)
                {
                    return NotFound(new ErrorResponse($"The inventory id was not found."));
                }

                await _inventoryRepository.UpdateAsync(inventoryUpdateDTO, id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var inventory = await _inventoryRepository.GetByIdAsync(id);

                if (inventory == null)
                {
                    return NotFound(new ErrorResponse($"The inventory id was not found."));
                }

                await _inventoryRepository.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }
    }
}
