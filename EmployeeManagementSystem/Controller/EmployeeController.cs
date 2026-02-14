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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Emp = new Employee
            {
                Name = lt.Name,
                Email = lt.Email,
                Phone = lt.phone,
                department = lt.Department,
                DepartmentId = lt.DepartmentId
                
            };

            await _repo.Employees.AddAsync(Emp);
            await _repo.SaveChangesAsync();
            return Ok("Saved Employee Details");
            
        }

    }
}
