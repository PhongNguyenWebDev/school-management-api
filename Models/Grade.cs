namespace SchoolManagementApi.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public int ClassSubjectTeacherId { get; set; }
        public ClassSubjectTeacher ClassSubjectTeacher { get; set; } = null!;
        public float Score { get; set; }
        public string GradeType { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Note { get; set; }
    }
} 