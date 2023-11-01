using HRIS.Basic.Models.Domain;
using HRIS.Basic.Models.DTO.User;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Basic.Repositories.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsers();
    Task<User?> GetUser(Guid id);
    Task<IActionResult> PutUser(Guid id, User user);
    Task<ActionResult<UserDTO>> PostUser(UserRequestDTO userRequest);
    Task<IActionResult> DeleteUser(Guid id);
    bool UserExists(Guid id);

}