using HRIS.Basic.Models.Domain;
using HRIS.Basic.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Basic.Repositories
{
    public class EmployeeRepository: IEmployeesRepository
    {
        public Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Employee>> GetEmployee(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> PutEmployee(Guid id, Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteEmployee(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
