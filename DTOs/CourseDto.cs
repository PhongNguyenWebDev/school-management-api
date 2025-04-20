namespace SchoolManagementApi.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int StartYear { get; set; }
        public int EndYear { get; set; }
    }
} 