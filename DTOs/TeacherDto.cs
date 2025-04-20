namespace SchoolManagementApi.DTOs
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string TeacherCode { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string SpecializedSubject { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
} 