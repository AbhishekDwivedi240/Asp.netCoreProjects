namespace StudentManagemetSystem.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Address { get; set; }
        public ICollection<StudentFee> studentFees { get; set; }
    }
}
