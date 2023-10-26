using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRIS.Basic.Data;
using HRIS.Basic.Models.Domain;
using HRIS.Basic.Models.DTO.SystemRole;

namespace HRIS.Basic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemRoleController : ControllerBase
    {
        private readonly HrisDbRevContext _context;

        public SystemRoleController(HrisDbRevContext context)
        {
            _context = context;
        }

        // GET: api/SystemRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemRole>>> GetSystemRoles()
        {
          if (_context.SystemRoles == null)
          {
              return NotFound();
          }
            return await _context.SystemRoles.ToListAsync();
        }

        // GET: api/SystemRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemRole>> GetSystemRole(Guid id)
        {
          if (_context.SystemRoles == null)
          {
              return NotFound();
          }
            var systemRole = await _context.SystemRoles.FindAsync(id);

            if (systemRole == null)
            {
                return NotFound();
            }

            return systemRole;
        }

        // PUT: api/SystemRole/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemRole(Guid id, SystemRole systemRole)
        {
            if (id != systemRole.SystemRoleId)
            {
                return BadRequest();
            }

            _context.Entry(systemRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemRoleExists(id))
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

        // POST: api/SystemRole
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SystemRoleDTO>> PostSystemRole(SystemRoleDTO systemRoleDto)
        {
          if (_context.SystemRoles == null)
          {
              return Problem("Entity set 'HrisDbRevContext.SystemRoles'  is null.");
          }

          var guid = Guid.NewGuid();
          var systemRoleModel = new SystemRole()
          {
              SystemRoleId = guid,
              RoleName = systemRoleDto.RoleName,
              CreatedAt = DateTime.Now,
              UpdatedAt = DateTime.Now,
              CreatedBy = guid,
              UpdatedBy = guid

          };

           await _context.SystemRoles.AddAsync(systemRoleModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SystemRoleExists(systemRoleModel.SystemRoleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSystemRole", new { id = systemRoleModel.SystemRoleId }, systemRoleModel);
        }

        // DELETE: api/SystemRole/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystemRole(Guid id)
        {
            if (_context.SystemRoles == null)
            {
                return NotFound();
            }
            var systemRole = await _context.SystemRoles.FindAsync(id);
            if (systemRole == null)
            {
                return NotFound();
            }

            _context.SystemRoles.Remove(systemRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SystemRoleExists(Guid id)
        {
            return (_context.SystemRoles?.Any(e => e.SystemRoleId == id)).GetValueOrDefault();
        }
    }
}
