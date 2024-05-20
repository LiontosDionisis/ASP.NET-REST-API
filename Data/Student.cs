namespace RESTAPI.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; } = null!;
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Course> Courses { get; } = new HashSet<Course>();

        public override string ToString()
        {
            return $"{User!.Firstname}, {User.Lastname}, {PhoneNumber}";
        }
    }
}
