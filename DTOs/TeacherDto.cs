using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApi.DTOs
{
    public class TeacherDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Phone]
        public string? Phone { get; set; }
        [Required]
        public string TeacherCode { get; set; } = null!;
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;
        [Required]
        public string SpecializedSubject { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
} 