using FerreteriaApi.DTOs;
using FerreteriaApi.DTOs.Responses;
using FerreteriaApi.DTOs.user_sys;
using FerreteriaApi.Repository.AuthenticateRepositories;
using FerreteriaApi.Services.TokenGenerators;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaApi.Controllers
{
    [ApiController]
    [Route("api/authenticate")]
    public class AuthenticateController : ControllerBase
    {
        
        private readonly IAuthenticateRepository _authenticateRepository;
        private readonly AccessTokenGenerator _accessTokenGenerator;
        public AuthenticateController(IAuthenticateRepository authenticateRepository, AccessTokenGenerator accessTokenGenerator)
        {
            this._authenticateRepository = authenticateRepository;
            this._accessTokenGenerator = accessTokenGenerator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegister userRegister)
        {
            try
            {
                if(!userRegister.Password.Equals(userRegister.ConfirmPassword))
                {
                    return BadRequest(new ErrorResponse("Password don't match wit ConfirmPassword"));
                }

                var userAlreadyRegister = await _authenticateRepository.GetByUsername(userRegister.UserName);

                if (userAlreadyRegister != null)
                {
                    return BadRequest(new ErrorResponse("This username is already registered."));
                }

                await _authenticateRepository.Create(userRegister);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseAuthentication>> Login(UserLogin userLogin)
        {
            try
            {
                var existByUsername = await _authenticateRepository.GetByUsername(userLogin.UserName);
                
                if (existByUsername == null)
                {
                    return Unauthorized();
                }

                var user = await _authenticateRepository.GetByUsernameAndPassword(userLogin.UserName, userLogin.Password);

                if(user == null)
                {
                    return Unauthorized();
                }

                var token = _accessTokenGenerator.GenerateToken(user);
                user.Token = token;

                return Ok(user);
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorResponse($"Exception: {ex.Message}"));
            }
        }
        
    }
}
