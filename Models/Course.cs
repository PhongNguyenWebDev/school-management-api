using System.Collections.Generic;

namespace SchoolManagementApi.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Class> Classes { get; set; } = new List<Class>();
    }
} 