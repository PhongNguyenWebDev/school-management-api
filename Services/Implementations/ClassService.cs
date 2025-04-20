using SchoolManagementApi.DTOs;
using SchoolManagementApi.Models;
using SchoolManagementApi.Repositories.Interfaces;
using SchoolManagementApi.Services.Interfaces;

namespace SchoolManagementApi.Services.Implementations
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _repo;

        public ClassService(IClassRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ClassDto>> GetAllAsync()
        {
            var classes = await _repo.GetAllAsync();
            return classes.Select(c => new ClassDto
            {
                Id = c.Id,
                Name = c.Name,
                CourseId = c.CourseId,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt
            });
        }

        public async Task<ClassDto?> GetByIdAsync(int id)
        {
            var c = await _repo.GetByIdAsync(id);
            if (c == null) return null;
            return new ClassDto
            {
                Id = c.Id,
                Name = c.Name,
                CourseId = c.CourseId,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt
            };
        }

        public async Task<ClassDto> AddAsync(ClassDto dto)
        {
            var c = new Class
            {
                Name = dto.Name,
                CourseId = dto.CourseId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            await _repo.AddAsync(c);
            dto.Id = c.Id;
            dto.CreatedAt = c.CreatedAt;
            dto.UpdatedAt = c.UpdatedAt;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, ClassDto dto)
        {
            var c = await _repo.GetByIdAsync(id);
            if (c == null) return false;
            c.Name = dto.Name;
            c.CourseId = dto.CourseId;
            c.UpdatedAt = DateTime.UtcNow;
            await _repo.UpdateAsync(c);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var c = await _repo.GetByIdAsync(id);
            if (c == null) return false;
            await _repo.DeleteAsync(id);
            return true;
        }
    }
} 