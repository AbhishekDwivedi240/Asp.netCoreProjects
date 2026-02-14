using EmployeeManagementSystem.DTO;
using EmployeeManagementSystem.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmetnController : ControllerBase
    {
        private AppDbContext _con;

        public DepartmetnController(AppDbContext con) {
        _con = con;
        }
        [HttpPost]
        public async Task<IActionResult> addDepartment(DepartmentDto dt)
        {
            var dprt = new Department
            {
                Name = dt.Department
            };
            await _con.AddAsync(dprt);
            await _con.SaveChangesAsync();

            return Ok("saved Department");
        }
    }
}
