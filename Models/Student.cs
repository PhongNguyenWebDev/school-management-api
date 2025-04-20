using System.Collections.Generic;

namespace SchoolManagementApi.Models
{
    public class Student
    {
        // Các thuộc tính của class Student
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; } = null!;
        public string StudentCode { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}