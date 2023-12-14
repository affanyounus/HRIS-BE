using System.Security.Claims;
using HRIS.Basic.Authorization;
using HRIS.Basic.Models.DTO.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Basic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly HrisDbRevContext _dbRevContext;

        public EmployeeController(HrisDbRevContext hrisDbRevContextContext)
        {
            _dbRevContext = hrisDbRevContextContext;
        }

        [HttpGet]
        [Authorize(Policy = "AdminPermissions")]
        public async Task<IActionResult> Index()
        {
            //return Ok();
            return Ok(await _dbRevContext.Employees.ToListAsync());
        }


        [HttpGet]
        [Route("burncheck")]
        public IActionResult GetBurnCheck()
        {
            return Ok("You have literally burned up!");
        }


        [HttpPost]
        public async Task<ActionResult<EmployeeRequestDTO>> PostEmployee(EmployeeRequestDTO employeeRequestDto)
        {
            return Ok();
        }
    }
}
