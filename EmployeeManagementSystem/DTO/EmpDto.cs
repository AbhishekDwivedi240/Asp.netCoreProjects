using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.DTO
{
    public class EmpDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]

        public string Department { get; set; }
        public string phone { get; set; }
        public int DepartmentId { get; set; }


    }
}
