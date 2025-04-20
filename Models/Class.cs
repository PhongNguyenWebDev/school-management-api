using System.Collections.Generic;

namespace SchoolManagementApi.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<ClassSubjectTeacher> ClassSubjectTeachers { get; set; } = new List<ClassSubjectTeacher>();
    }
} 