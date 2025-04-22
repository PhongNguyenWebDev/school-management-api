using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementApi.Models; // Đảm bảo namespace này đúng
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

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

                // Seed Admins
                if (!context.Admins.Any())
                {
                    var admins = Enumerable.Range(1, 10).Select(i => new Admin
                    {
                        Username = $"admin{i}",
                        PasswordHash = $"hash{i}",
                        Password = $"admin{i}123",
                        Email = $"admin{i}@school.com",
                        Name = $"Admin {i}",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }).ToArray();
                    context.Admins.AddRange(admins);
                    context.SaveChanges();
                }

                // Seed Courses
                if (!context.Courses.Any())
                {
                    var courses = Enumerable.Range(1, 10).Select(i => new Course
                    {
                        Name = $"Khóa {i}",
                        StartYear = 2020 + i,
                        EndYear = 2021 + i,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }).ToArray();
                    context.Courses.AddRange(courses);
                    context.SaveChanges();
                }

                // Seed Classes
                if (!context.Classes.Any())
                {
                    var courseIds = context.Courses.Select(c => c.Id).ToList();
                    var classes = Enumerable.Range(1, 10).Select(i => new Class
                    {
                        Name = $"Lớp {i}",
                        CourseId = courseIds[i % courseIds.Count],
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }).ToArray();
                    context.Classes.AddRange(classes);
                    context.SaveChanges();
                }

                // Seed Subjects
                if (!context.Subjects.Any())
                {
                    var subjects = Enumerable.Range(1, 10).Select(i => new Subject
                    {
                        Name = $"Môn {i}",
                        Description = $"Mô tả môn {i}",
                        SubjectCode = $"SUBJ{i:000}",
                        Credits = (byte)(2 + (i % 4)),
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }).ToArray();
                    context.Subjects.AddRange(subjects);
                    context.SaveChanges();
                }

                // Seed Teachers
                if (!context.Teachers.Any())
                {
                    var teachers = Enumerable.Range(1, 10).Select(i => new Teacher
                    {
                        Name = $"Giáo viên {i}",
                        Email = $"teacher{i}@school.com",
                        Phone = $"09000000{i:00}",
                        TeacherCode = $"TCHR{i:000}",
                        Password = $"teacher{i}123",
                        SpecializedSubject = $"Môn {((i-1)%10)+1}",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }).ToArray();
                    context.Teachers.AddRange(teachers);
                    context.SaveChanges();
                }

                // Seed Students
                if (!context.Students.Any())
                {
                    var classIds = context.Classes.Select(c => c.Id).ToList();
                    var students = Enumerable.Range(1, 10).Select(i => new Student
                    {
                        Name = $"Học sinh {i}",
                        Age = 15 + (i % 5),
                        ClassId = classIds[i % classIds.Count],
                        StudentCode = $"STD{i:000}",
                        Email = $"student{i}@school.com",
                        Password = $"student{i}123",
                        DateOfBirth = DateTime.UtcNow.AddYears(-15 - (i % 5)),
                        Gender = (i % 2 == 0) ? "Nam" : "Nữ",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }).ToArray();
                    context.Students.AddRange(students);
                    context.SaveChanges();
                }

                // Seed ClassSubjectTeachers
                if (!context.ClassSubjectTeachers.Any())
                {
                    var classIds = context.Classes.Select(c => c.Id).ToList();
                    var subjectIds = context.Subjects.Select(s => s.Id).ToList();
                    var teacherIds = context.Teachers.Select(t => t.Id).ToList();
                    var cstList = new List<ClassSubjectTeacher>();
                    for (int i = 0; i < 10; i++)
                    {
                        cstList.Add(new ClassSubjectTeacher
                        {
                            ClassId = classIds[i % classIds.Count],
                            SubjectId = subjectIds[i % subjectIds.Count],
                            TeacherId = teacherIds[i % teacherIds.Count],
                            Semester = $"HK{(i % 2) + 1}",
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        });
                    }
                    context.ClassSubjectTeachers.AddRange(cstList);
                    context.SaveChanges();
                }

                // Seed Grades
                if (!context.Grades.Any())
                {
                    var studentIds = context.Students.Select(s => s.Id).ToList();
                    var cstIds = context.ClassSubjectTeachers.Select(cst => cst.Id).ToList();
                    var grades = new List<Grade>();
                    for (int i = 0; i < 10; i++)
                    {
                        grades.Add(new Grade
                        {
                            StudentId = studentIds[i % studentIds.Count],
                            ClassSubjectTeacherId = cstIds[i % cstIds.Count],
                            Score = (float)(5 + (i % 6) + 0.5 * (i % 2)),
                            GradeType = (i % 2 == 0) ? "Giữa kỳ" : "Cuối kỳ",
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow,
                            Note = $"Ghi chú {i}"
                        });
                    }
                    context.Grades.AddRange(grades);
                    context.SaveChanges();
                }
            }
        }
    }
}