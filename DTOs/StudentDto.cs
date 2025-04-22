namespace SchoolManagementApi.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class StudentDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [Range(1, 150)]
        public int Age { get; set; }
        [Required]
        public int ClassId { get; set; }
        [Required]
        public string StudentCode { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
