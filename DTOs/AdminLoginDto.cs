using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApi.DTOs
{
    public class AdminLoginDto
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
} 