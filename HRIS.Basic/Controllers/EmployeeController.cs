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
        public async Task<IActionResult> Index()
        {
            //return Ok();
            return Ok(await _dbRevContext.Employees.ToListAsync());
        }
    }
}
