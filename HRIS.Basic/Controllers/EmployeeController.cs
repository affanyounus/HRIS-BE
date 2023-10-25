using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Basic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {

        private readonly HrisDbRevContext _dbRevContext;

        public EmployeeController(HrisDbRevContext hrisDbRevContextContext)
        {
            _dbRevContext = hrisDbRevContextContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _dbRevContext.Employees.ToListAsync());
        }
    }
}
