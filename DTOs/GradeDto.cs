namespace SchoolManagementApi.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class GradeDto
    {
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int ClassSubjectTeacherId { get; set; }
        [Range(0, 10)]
        public float Score { get; set; }
        [Required]
        [StringLength(50)]
        public string GradeType { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [StringLength(255)]
        public string? Note { get; set; }
    }
} 