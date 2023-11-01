using HRIS.Basic.Models.Domain;
using HRIS.Basic.Models.DTO.User;
using HRIS.Basic.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Basic.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly HrisDbRevContext _dbContext;
        public UserRepository(HrisDbRevContext dbRevContext)
        {
            _dbContext = dbRevContext;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetUser(Guid id)
        {

            if (_dbContext.Users != null)
            {
                return await _dbContext.Users.FindAsync(id);
            }

            return null;

        }

        public Task<IActionResult> PutUser(Guid id, User user)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<UserDTO>> PostUser(UserRequestDTO userRequest)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

       public bool UserExists(Guid id)
        {
            return (_dbContext.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
