using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Models; // Đảm bảo namespace này đúng với nơi bạn đặt các model

namespace SchoolManagementApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Định nghĩa các DbSet cho các entity của bạn
        public DbSet<Student> Students { get; set; }
        // Thêm các DbSet khác cho các model khác (ví dụ: Courses, Teachers, Classes, etc.)
        // public DbSet<Course> Courses { get; set; }
        // public DbSet<Teacher> Teachers { get; set; }
        // public DbSet<Class> Classes { get; set; }
        // public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình các relationship, khóa chính/phụ, ràng buộc dữ liệu (nếu cần)
            // Ví dụ:
            // modelBuilder.Entity<Enrollment>()
            //     .HasKey(e => new { e.StudentId, e.CourseId });

            // modelBuilder.Entity<Enrollment>()
            //     .HasOne(e => e.Student)
            //     .WithMany(s => s.Enrollments)
            //     .HasForeignKey(e => e.StudentId);

            // modelBuilder.Entity<Enrollment>()
            //     .HasOne(e => e.Course)
            //     .WithMany(c => c.Enrollments)
            //     .HasForeignKey(e => e.CourseId);
        }
    }
}