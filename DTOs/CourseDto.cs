using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApi.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [Required]
        [Range(2000, 2100)]
        public int StartYear { get; set; }
        [Required]
        [Range(2000, 2100)]
        public int EndYear { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
} 