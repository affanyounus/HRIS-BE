using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRIS.Basic.Data;
using HRIS.Basic.Models.Domain;
using HRIS.Basic.Models.Domain.Auth;
using HRIS.Basic.Models.DTO.User;
using HRIS.Basic.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace HRIS.Basic.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly HrisDbRevContext _dbRevContext;
        private readonly HrisDbAuthContext _dbAuthContext;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(HrisDbRevContext dbRevContext, IUserRepository userRepository, IMapper mapper)
        {
            _dbRevContext = dbRevContext;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
          //if (_dbRevContext.Users == null)
          //{
          //    return NotFound();
          //}
            //var usersList = await _dbRevContext.Users.ToListAsync();

            var usersList = await _userRepository.GetUsers();

            //List<UserDTO> userDtos = new List<UserDTO>();

            //foreach (var user in usersList)
            //{
            //    userDtos.Add(new UserDTO
            //    {
            //        UserId = user.UserId,
            //        SystemRoleId = user.SystemRoleId,
            //        FirstName = user.FirstName,
            //        LastName = user.LastName,
            //        Email = user.Email,
            //        Password = user.Password,
            //        IsActive = user.IsActive,
            //        CreatedAt = user.CreatedAt,
            //        UpdatedAt = user.UpdatedAt,
            //        CreatedBy = user.CreatedBy,
            //        UpdatedBy = user.UpdatedBy
            //    });

            //}

            //Map Domain Model to DTO
            var usersDto = _mapper.Map<List<UserDTO>>(usersList);


            return Ok(usersDto);

        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(Guid id)
        {

            var user = await _userRepository.GetUser(id);

            if (user == null)
          {
              return NotFound();
          }

            //var userDto = new UserDTO
            //{
            //    UserId = user.UserId,
            //    SystemRoleId = user.SystemRoleId,
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    Email = user.Email,
            //    Password = user.Password,
            //    IsActive = user.IsActive,
            //    CreatedAt = user.CreatedAt,
            //    UpdatedAt = user.UpdatedAt,
            //    CreatedBy = user.CreatedBy,
            //    UpdatedBy = user.UpdatedBy
            //};

            var userDto = _mapper.Map<UserDTO>(user);

            return Ok(userDto);
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, ApplicationUser user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _dbRevContext.Entry(user).State = EntityState.Modified;

            try
            {
                await _dbRevContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_userRepository.UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserRequestDTO>> PostUser(UserRequestDTO userRequest)
        {
          if (_dbRevContext.Users == null)
          {
              return Problem("Entity set 'HrisDbRevContext.Users'  is null.");
          }

          if (!ModelState.IsValid)
          {
              return UnprocessableEntity(ModelState);
          }

            var userModel = new ApplicationUser()
            {
                UserName = userRequest.Email,
                Email = userRequest.Email,
                PasswordHash = userRequest.Password,
                LockoutEnabled = false,
                //SystemRoleId = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6")

            };

            _dbRevContext.Users.Add(userModel);
            try
            {
                await _dbRevContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (_userRepository.UserExists(userModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            var userDto = _mapper.Map<UserDTO>(userModel);

            return CreatedAtAction(nameof(GetUser), new { id = userDto.Id }, userDto);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            if (_dbRevContext.Users == null)
            {
                return NotFound();
            }
            var user = await _dbRevContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _dbRevContext.Users.Remove(user);
            await _dbRevContext.SaveChangesAsync();

            return NoContent();
        }

        
    }
}
