using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagemetSystem.DTO;
using StudentManagemetSystem.Model;

namespace StudentManagemetSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentFeeController : ControllerBase
    {
        private readonly AppDbContext _Contex;

        public StudentFeeController(AppDbContext dbContext) {
         _Contex = dbContext;

        }
        [HttpPost]
        public async Task<IActionResult> Post(StudentFeeDto dto)
        {
            var fee = new StudentFee
            {
                StudentId = dto.StudentId,
                Totalfee = dto.TotalFee,
                TotalPaid = dto.TotalPaid,
                paymetMode = dto.PaymentMode,
                PaymentDate = dto.PaymentDate,
            };


            _Contex.studentFee.Add(fee);
            await _Contex.SaveChangesAsync();
            return Ok(fee);
         
        }
    }
}
