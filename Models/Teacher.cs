using System.Collections.Generic;

namespace SchoolManagementApi.Models
{
    public class Teacher
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

        public ICollection<ClassSubjectTeacher> ClassSubjectTeachers { get; set; } = new List<ClassSubjectTeacher>();
    }
} 