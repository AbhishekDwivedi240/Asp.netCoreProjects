using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagemetSystem.Model
{
    public class StudentFee
    {

        public int Id { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public decimal Totalfee { get; set; }
        public decimal TotalPaid {  get; set; }

        public string paymetMode { get; set; }
        public DateTime PaymentDate {  get; set; }

    }
}
