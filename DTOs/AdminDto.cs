using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApi.DTOs
{
    public class AdminDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = null!;
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
} 