using HRIS.Basic.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Basic.Repositories.Interfaces;

public interface IEmployeesRepository
{
    Task<ActionResult<IEnumerable<Employee>>> GetEmployees();
    Task<ActionResult<Employee>> GetEmployee(Guid id);
    Task<IActionResult> PutEmployee(Guid id, Employee employee);
    Task<ActionResult<Employee>> PostEmployee(Employee employee);
    Task<IActionResult> DeleteEmployee(Guid id);
}