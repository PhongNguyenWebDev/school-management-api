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
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ClassSubjectTeacher> ClassSubjectTeachers { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình quan hệ nhiều-nhiều thông qua bảng trung gian ClassSubjectTeacher
            modelBuilder.Entity<ClassSubjectTeacher>()
                .HasOne(cst => cst.Class)
                .WithMany(c => c.ClassSubjectTeachers)
                .HasForeignKey(cst => cst.ClassId);

            modelBuilder.Entity<ClassSubjectTeacher>()
                .HasOne(cst => cst.Subject)
                .WithMany(s => s.ClassSubjectTeachers)
                .HasForeignKey(cst => cst.SubjectId);

            modelBuilder.Entity<ClassSubjectTeacher>()
                .HasOne(cst => cst.Teacher)
                .WithMany(t => t.ClassSubjectTeachers)
                .HasForeignKey(cst => cst.TeacherId);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.ClassSubjectTeacher)
                .WithMany(cst => cst.Grades)
                .HasForeignKey(g => g.ClassSubjectTeacherId);
        }
    }
}