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

        public StudentController(AppDbContext repo)
        {
            _repo = repo;


        }
        [HttpGet]
        public async Task<IActionResult> GetStudentData()
        {
            var student = await _repo.students.Include(s => s.studentFees)
                         .Select(s => new
                         {
                             s.Id,
                             s.Name,
                             s.Address,
                             Totalfee = s.studentFees.Sum(s => s.Totalfee),
                             totalPaid = s.studentFees.Sum(s => s.TotalPaid),
                             status =
                             (s.studentFees.Sum(f => (decimal?)f.Totalfee) ?? 0) == 0 ? "No fee" : (s.studentFees.Sum(f => (decimal?)f.TotalPaid) ?? 0) == 0 ? "Unpaid" :
                             (s.studentFees.Sum(f => (decimal?)f.TotalPaid) ?? 0) >= (s.studentFees.Sum(f => (decimal?)f.Totalfee) ?? 0) ? "Paid" : "Pendding"
                         })
                         .ToListAsync();


            return Ok(student);

        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student st)
        {
            _repo.students.Add(st);
            await _repo.SaveChangesAsync();
            return Ok(st);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var s = await _repo.students.FindAsync(id);

            if (s == null)
            
                return NotFound("Student Not Found");
            
            _repo.students.Remove(s);
            await _repo.SaveChangesAsync();
            return Ok("Delete Successfull");

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id , Student s)
        {
            if(id != s.Id)
            
                return BadRequest("Id Do not Match");
            var su = await _repo.students.FindAsync(id);
            if (su == null)
                return NotFound("Student Not found");

            su.Name = s.Name;
            su.Address = s.Address;
            su.Class = s.Class;
            await _repo.SaveChangesAsync();
            return Ok("Updated");



        }
    }
}
