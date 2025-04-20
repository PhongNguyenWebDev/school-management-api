using SchoolManagementApi.DTOs;
using SchoolManagementApi.Models;
using SchoolManagementApi.Repositories.Interfaces;
using SchoolManagementApi.Services.Interfaces;

namespace SchoolManagementApi.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repo;

        public CourseService(ICourseRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CourseDto>> GetAllAsync()
        {
            var courses = await _repo.GetAllAsync();
            return courses.Select(c => new CourseDto
            {
                Id = c.Id,
                Name = c.Name,
                StartYear = c.StartYear,
                EndYear = c.EndYear,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt
            });
        }

        public async Task<CourseDto?> GetByIdAsync(int id)
        {
            var c = await _repo.GetByIdAsync(id);
            if (c == null) return null;
            return new CourseDto
            {
                Id = c.Id,
                Name = c.Name,
                StartYear = c.StartYear,
                EndYear = c.EndYear,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt
            };
        }

        public async Task<CourseDto> AddAsync(CourseDto dto)
        {
            var course = new Course
            {
                Name = dto.Name,
                StartYear = dto.StartYear,
                EndYear = dto.EndYear,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            await _repo.AddAsync(course);
            dto.Id = course.Id;
            dto.CreatedAt = course.CreatedAt;
            dto.UpdatedAt = course.UpdatedAt;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, CourseDto dto)
        {
            var course = await _repo.GetByIdAsync(id);
            if (course == null) return false;
            course.Name = dto.Name;
            course.StartYear = dto.StartYear;
            course.EndYear = dto.EndYear;
            course.UpdatedAt = DateTime.UtcNow;
            await _repo.UpdateAsync(course);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _repo.GetByIdAsync(id);
            if (course == null) return false;
            await _repo.DeleteAsync(id);
            return true;
        }
    }
} 