using EmployeeManagementSystem.DTO;
using EmployeeManagementSystem.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeManagementSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private AppDbContext _Context;

        public LoginController(AppDbContext context) { 
          _Context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(LoginDto login)
        {
            var us = new Users
            {
                UserName = login.UserName,
                Password = login.Password,
            };
            await _Context.AddAsync(us);
            await _Context.SaveChangesAsync();
            return Ok(us);
        
        }
  

    }
}
