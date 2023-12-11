using HRIS.Basic.Models.Domain.Auth;
using HRIS.Basic.Models.DTO.AuthUser;
using HRIS.Basic.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Basic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<ApplicationUser> userManager, ITokenRepository tokenRepository)
        {
            this._userManager = userManager;
            this._tokenRepository = tokenRepository;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<AuthRegisterRequestDTO>> Register([FromBody] AuthRegisterRequestDTO authRegisterRequestDto )
        {

            var applicationUser = new ApplicationUser
            {
                UserName = authRegisterRequestDto.UserName,
                Email = authRegisterRequestDto.UserName,

            };

            var identityResult = await _userManager.CreateAsync(applicationUser, authRegisterRequestDto.Password);

            if (identityResult.Succeeded)
            {
                //add roles to the user
                IEnumerable<string> roles = new[] { "Viewer", "Editor" };
                identityResult = await _userManager.AddToRolesAsync(applicationUser, roles);

                if (identityResult.Succeeded)
                {
                    return Ok(identityResult);
                }

                else
                {
                    return BadRequest(identityResult);
                }


               
            }


            return BadRequest(identityResult);
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthLoginRequestDTO>> Login([FromBody] AuthLoginRequestDTO authLoginRequestDto)
        {

            var user = await _userManager.FindByEmailAsync(authLoginRequestDto.UserName);

            if (user == null)
            {
                return BadRequest("username or password is incorrect");
            }

            var isValidPassword = await _userManager.CheckPasswordAsync(user, authLoginRequestDto.Password);

            if (!isValidPassword)
            {
                return BadRequest("username or password is incorrect");
            }

            var roles = await _userManager.GetRolesAsync(user);

            if (roles == null)
            {
                return BadRequest("username or password is incorrect");
            }

            //create Token
            var token = _tokenRepository.CreateJWTToken(user, roles.ToList());

            var response = new AuthLoginResponseDTO
            {
                JWTToken = token
            };

            return Ok(response);

        }
    }
}
