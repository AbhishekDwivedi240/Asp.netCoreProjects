using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.DTO
{
    public class DepartmentDto
    {
        [Required]
        public string Department {  get; set; }
    }
}
