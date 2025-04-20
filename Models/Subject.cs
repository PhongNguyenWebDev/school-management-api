using System.Collections.Generic;

namespace SchoolManagementApi.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string SubjectCode { get; set; } = null!;
        public byte Credits { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<ClassSubjectTeacher> ClassSubjectTeachers { get; set; } = new List<ClassSubjectTeacher>();
    }
} 