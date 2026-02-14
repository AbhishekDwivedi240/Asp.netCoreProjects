using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Model
{
    public class Users
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
