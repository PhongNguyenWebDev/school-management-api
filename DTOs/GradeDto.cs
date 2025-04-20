namespace SchoolManagementApi.DTOs
{
    public class GradeDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassSubjectTeacherId { get; set; }
        public float Score { get; set; }
        public string GradeType { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Note { get; set; }
    }
} 