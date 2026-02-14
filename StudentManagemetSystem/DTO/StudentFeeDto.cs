using System.ComponentModel.DataAnnotations;

namespace StudentManagemetSystem.DTO
{
    public class StudentFeeDto
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public decimal TotalFee { get; set; }

        [Required]
        public decimal TotalPaid { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public string PaymentMode { get; set; }
    }
}
