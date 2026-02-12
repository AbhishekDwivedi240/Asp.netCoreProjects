using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagemetSystem.Model;

namespace StudentManagemetSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _repo;

        public StudentController(AppDbContext repo) {
            _repo = repo;
        
        
        }
        [HttpGet]
        public async Task<IActionResult> GetStudentData()
        {
            var student = await _repo.students.Include(s => s.studentFees)
                         .Select(s => new
                         {
                             s.Id, s.Name, s.Address, Totalfee = s.studentFees.Sum(s => s.Totalfee),
                             totalPaid = s.studentFees.Sum(s => s.TotalPaid),
                             status =
                             (s.studentFees.Sum(f => (decimal?)f.Totalfee) ?? 0) == 0 ? "No fee" : (s.studentFees.Sum(f => (decimal?)f.TotalPaid) ?? 0) == 0 ? "Unpaid" :
                             (s.studentFees.Sum(f => (decimal?)f.TotalPaid) ?? 0) >= (s.studentFees.Sum(f => (decimal?)f.Totalfee) ?? 0) ? "Paid" : "Pendding"
                         })
                         .ToListAsync();


            return Ok(student);

        }

        public async Task<IActionResult> AddStudent(Student st)
        {
         _repo.students.Add(st);
            await _repo.SaveChangesAsync();
            return Ok(st);
        }
       
    }
}
