using AutoMapper;
using FerreteriaApi.DTOs.product_category;
using FerreteriaApi.DTOs.Responses;
using FerreteriaApi.Models;
using FerreteriaApi.Repository.ProductCatRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FerreteriaApi.Controllers
{
    [ApiController]
    [Route("api/productCat")]
    public class ProductCategoryController : ControllerBase
    {

        private readonly IProductCatRepository _productCatRepository;

        public ProductCategoryController(IProductCatRepository productCatRepository)
        {
            _productCatRepository = productCatRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ProductCategoryDTO>>> Get()
        {
            try
            {
                return await _productCatRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductCategoryDTO>> Get([FromRoute] int id)
        {
            try
            {
                var productCatDTO = await _productCatRepository.GetByIdAsync(id);

                if(productCatDTO == null)
                {
                    return NotFound(new ErrorResponse($"IdCategory {id} not found"));
                }

                return Ok(productCatDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }

        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ProductCategoryDTO>> Get([FromRoute] string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest(new ErrorResponse("The name must not be empty or null."));
                }

                var productCatDTO = await _productCatRepository.GetByNameAsync(name);

                if(productCatDTO == null)
                {
                    return NotFound($"Name category \"{name}\" not found.");
                }

                return Ok(productCatDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("contains/{name}")]
        public async Task<ActionResult<ProductCategoryDTO>> GetThatContainsName([FromRoute] string name)
        {
            try
            {
                var productsCat = await _productCatRepository.GetAllThatContainsNameAsync(name);

                return Ok(productsCat);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));

            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductCategoryCreateDTO categoryDTO)
        {
            try
            {
                var existByName = await _productCatRepository.GetByNameAsync(categoryDTO.Name);

                if (existByName != null)
                {
                    return BadRequest(new ErrorResponse("Error: this category has already been registered."));
                }

                await _productCatRepository.CreateAsync(categoryDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromBody] ProductCategoryUpdateDTO categoryDTO, [FromRoute] int id)
        {
            var categoryToUpdate = await _productCatRepository.GetByIdAsync(id);

            if (categoryToUpdate == null)
            {
                return NotFound(new ErrorResponse($"CategoryId {id} was not found."));
            }

            await _productCatRepository.UpdateAsync(categoryDTO, id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var category = await _productCatRepository.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound($"IdCategory {id} not exist.");
            }

            await _productCatRepository.DeleteAsync(id);
            
            return Ok();
        }



    }
}
