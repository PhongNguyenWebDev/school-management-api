using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Data;
using SchoolManagementApi.Models;
using SchoolManagementApi.Repositories.Interfaces;

namespace SchoolManagementApi.Repositories.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<Course> AddAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course?> UpdateAsync(Course course)
        {
            var existing = await _context.Courses.FindAsync(course.Id);
            if (existing == null) return null;
            existing.Name = course.Name;
            existing.StartYear = course.StartYear;
            existing.EndYear = course.EndYear;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return false;
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 