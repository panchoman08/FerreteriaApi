using AutoMapper;
using FerreteriaApi.DTOs.product;
using FerreteriaApi.DTOs.Responses;
using FerreteriaApi.DTOs.user_sys;
using FerreteriaApi.Models;
using FerreteriaApi.Repository.ProductRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FerreteriaApi.Controllers
{
    [ApiController]
    [Route("api/product")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRespository)
        {
            this._productRepository = productRespository;
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserModel
                {
                    UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    RolId = int.Parse(userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value),

                };
            }
            return null;
        }


        [HttpGet("all")]
        [ResponseCache(Duration = 5)]
        public async Task<ActionResult<List<ProductDTO>>> Get()
        {
            try
            {
                var products =  await _productRepository.GetAllAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));

            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Get([FromRoute] int id)
        {
            try
            {
                if (id == 0) return BadRequest(new ErrorResponse("The ID must be greater than 0"));

                var productDTO = await _productRepository.GetByIdAsync(id);

                if (productDTO == null)
                {
                    return NotFound(new ErrorResponse($"Id product: {id} was not found."));
                }

                return Ok(productDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpGet("sku/{sku}")]
        public async Task<ActionResult<ProductDTO>> GetBySku([FromRoute] string sku)
        {
            try
            {
                if (string.IsNullOrEmpty(sku)) return BadRequest(new ErrorResponse("The sku must not be null or empty."));

                var productDTO = await _productRepository.GetBySkuAsync(sku);

                if (productDTO == null)
                {
                    return NotFound(new ErrorResponse($"The sku{0} was not found."));
                }

                return Ok(productDTO);
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }


        [HttpGet("{name}")]
        public async Task<ActionResult<ProductDTO>> Get([FromRoute] string name)
        {
            try
            {
                if (String.IsNullOrEmpty(name))
                {
                    return BadRequest(new ErrorResponse("The name don't be null or empty."));
                }

                var productDTO = await _productRepository.GetByNameAsync(name);

                if (productDTO == null)
                {
                    return NotFound(new ErrorResponse($"The product \"{name}\" was not found."));
                }

                return Ok(productDTO);
            }
            catch (Exception ex)
            {
                return BadRequest($"Exception: {ex.Message}");
            }
        }

        [HttpGet("contains/{name}")]
        public async Task<ActionResult<List<ProductDTO>>> GetContains([FromRoute] string name)
        {
            try
            {
                if (String.IsNullOrEmpty(name)) return BadRequest(new ErrorResponse("The name don't be null or empty"));

                var products = await _productRepository.GetAllThatContainsNameAsync(name);

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CreateProductDTO createProductDTO)
        {
            try
            {
                var existProduct = await _productRepository.GetBySkuAsync(createProductDTO.Sku);

                if (existProduct != null)
                    return BadRequest(new ErrorResponse($"The {createProductDTO.Sku} has already been registered."));

                await _productRepository.CreateAsync(createProductDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromBody]ProductUpdateDTO productDTO, [FromRoute] int id)
        {
            try
            {
                var productToUpdate = await _productRepository.GetByIdAsync(id);

                if (productToUpdate == null) return BadRequest(new ErrorResponse($"Product id:{id} not found."));

                await _productRepository.UpdateAsync(productDTO, id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            try
            {
                var productById = await _productRepository.GetByIdAsync(id);

                if (productById == null) return NotFound(new ErrorResponse($"The productId:{id} was not found."));

                await _productRepository.DeleteAsync(id);

                return Ok("Product deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message} \n {ex.InnerException}"));
            }
        }
        
    }
}
