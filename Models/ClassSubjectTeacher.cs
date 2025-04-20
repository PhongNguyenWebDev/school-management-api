using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApi.Models
{
    public class ClassSubjectTeacher
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; } = null!;
        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;

        [Required, StringLength(10)]
        public string Semester { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
} 