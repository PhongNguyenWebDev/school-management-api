namespace SchoolManagementApi.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class ClassDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [Required]
        public int CourseId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
} 