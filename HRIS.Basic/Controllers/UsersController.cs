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
using HRIS.Basic.Models.DTO.User;
using HRIS.Basic.Repositories.Interfaces;

namespace HRIS.Basic.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly HrisDbRevContext _dbContext;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(HrisDbRevContext dbContext, IUserRepository userRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
          if (_dbContext.Users == null)
          {
              return NotFound();
          }
            //var usersList = await _dbContext.Users.ToListAsync();

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
        public async Task<IActionResult> PutUser(Guid id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _dbContext.Entry(user).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
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
          if (_dbContext.Users == null)
          {
              return Problem("Entity set 'HrisDbRevContext.Users'  is null.");
          }

          if (!ModelState.IsValid)
          {
              return UnprocessableEntity(ModelState);
          }

            var userModel = new User()
            {
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                Email = userRequest.Email,
                Password = userRequest.Password,
                IsActive = true,
                SystemRoleId = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6")

            };

            _dbContext.Users.Add(userModel);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (_userRepository.UserExists(userModel.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            var userDto = _mapper.Map<UserDTO>(userModel);

            return CreatedAtAction(nameof(GetUser), new { id = userDto.UserId }, userDto);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            if (_dbContext.Users == null)
            {
                return NotFound();
            }
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        
    }
}
