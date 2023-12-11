using HRIS.Basic.Models.Domain;
using HRIS.Basic.Models.Domain.Auth;
using HRIS.Basic.Models.DTO.User;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Basic.Repositories.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<ApplicationUser>> GetUsers();
    Task<ApplicationUser?> GetUser(Guid id);
    Task<IActionResult> PutUser(Guid id, ApplicationUser user);
    Task<ActionResult<UserDTO>> PostUser(UserRequestDTO userRequest);
    Task<IActionResult> DeleteUser(Guid id);
    bool UserExists(Guid id);

}