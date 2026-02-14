using EmployeeManagementSystem.DTO;
using EmployeeManagementSystem.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _repo;

        public EmployeeController(AppDbContext repo) {
          
            _repo = repo;
        
        }
        [HttpPost]
        public async Task<IActionResult> Post(EmpDto lt)
        {
            var Employee = new Employee
            {
                Name = lt.Name,
                Email = lt.Email,
                department = lt.Department
            };

            await _repo.Employees.AddAsync(Employee);
            await _repo.SaveChangesAsync();
            return Ok("Saved Employee Details");
            
        }

    }
}
