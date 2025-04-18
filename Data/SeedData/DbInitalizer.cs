using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementApi.Models; // Đảm bảo namespace này đúng

namespace SchoolManagementApi.Data.SeedData
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Kiểm tra xem database đã được tạo chưa
                context.Database.EnsureCreated();

                // Kiểm tra xem đã có học sinh nào chưa
                if (context.Students.Any())
                {
                    return; // Database đã được seed
                }

                // Thêm dữ liệu mẫu (ví dụ: học sinh)
                var students = new Student[]
                {
                    new Student { Name = "Nguyễn Văn A", Age = 16 },
                    new Student { Name = "Trần Thị B", Age = 17 },
                    new Student { Name = "Lê Văn C", Age = 15 }
                };

                foreach (Student s in students)
                {
                    context.Students.Add(s);
                }
                context.SaveChanges();

                // Thêm dữ liệu mẫu cho các bảng khác (nếu cần)
                // Ví dụ:
                // var courses = new Course[]
                // {
                //     new Course { CourseName = "Toán", Credits = 3 },
                //     new Course { CourseName = "Văn", Credits = 3 }
                // };
                // foreach (Course c in courses)
                // {
                //     context.Courses.Add(c);
                // }
                // context.SaveChanges();
            }
        }
    }
}