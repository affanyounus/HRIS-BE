using System.Security.Claims;
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
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<ApplicationUser> userManager, ITokenRepository tokenRepository, SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._tokenRepository = tokenRepository;
            this._signInManager = signInManager;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<AuthRegisterRequestDTO>> Register([FromBody] AuthRegisterRequestDTO authRegisterRequestDto )
        {

            var applicationUser = new ApplicationUser
            {
                UserName = authRegisterRequestDto.UserName,
                Email = authRegisterRequestDto.UserName,
                FullName = authRegisterRequestDto.FullName

            };

            var identityUser = await _userManager.CreateAsync(applicationUser, authRegisterRequestDto.Password);

            if (identityUser.Succeeded)
            {
                //add roles to the user
                IEnumerable<string> roles = new[] { "Administrator" };
                var identityRoles = await _userManager.AddToRolesAsync(applicationUser, roles);
                
                if (!identityRoles.Succeeded)
                {
                    return BadRequest(identityRoles);
                }

                var claim = new Claim(ClaimTypes.Role, "burnupass");

                var identityClaim = await _userManager.AddClaimAsync(applicationUser, claim);

                if (!identityClaim.Succeeded)
                {
                    return BadRequest(identityClaim);
                }

                return Ok(identityUser);
            }


            return BadRequest(identityUser);
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

            var claims = await _userManager.GetClaimsAsync(user);

            if (roles == null)
            {
                return BadRequest("username or password is incorrect");
            }

            //create Token
            var token = _tokenRepository.CreateJWTToken(user, roles.ToList(), (List<Claim>)claims);

            var response = new AuthLoginResponseDTO
            {
                JWTToken =  token
            };

            return Ok(response);

        }
    }
}
