using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public string department {  get; set; }
    }
}
