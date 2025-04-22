using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApi.DTOs
{
    public class ClassSubjectTeacherDto
    {
        public int Id { get; set; }
        [Required]
        public int ClassId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Required]
        [StringLength(10)]
        public string Semester { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
} 