using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApi.DTOs
{
    public class SubjectDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [StringLength(255)]
        public string? Description { get; set; }
        [Required]
        public string SubjectCode { get; set; } = null!;
        [Range(1, 20)]
        public byte Credits { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
} 