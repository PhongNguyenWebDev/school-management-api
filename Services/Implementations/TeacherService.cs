using SchoolManagementApi.DTOs;
using SchoolManagementApi.Models;
using SchoolManagementApi.Repositories.Interfaces;
using SchoolManagementApi.Services.Interfaces;

namespace SchoolManagementApi.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repo;

        public TeacherService(ITeacherRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TeacherDto>> GetAllAsync()
        {
            var teachers = await _repo.GetAllAsync();
            return teachers.Select(t => new TeacherDto
            {
                Id = t.Id,
                TeacherCode = t.TeacherCode,
                Name = t.Name,
                Email = t.Email,
                Password = t.Password,
                SpecializedSubject = t.SpecializedSubject,
                CreatedAt = t.CreatedAt,
                UpdatedAt = t.UpdatedAt
            });
        }

        public async Task<TeacherDto?> GetByIdAsync(int id)
        {
            var t = await _repo.GetByIdAsync(id);
            if (t == null) return null;
            return new TeacherDto
            {
                Id = t.Id,
                TeacherCode = t.TeacherCode,
                Name = t.Name,
                Email = t.Email,
                Password = t.Password,
                SpecializedSubject = t.SpecializedSubject,
                CreatedAt = t.CreatedAt,
                UpdatedAt = t.UpdatedAt
            };
        }

        public async Task<TeacherDto> AddAsync(TeacherDto dto)
        {
            var t = new Teacher
            {
                TeacherCode = dto.TeacherCode,
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                SpecializedSubject = dto.SpecializedSubject,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            await _repo.AddAsync(t);
            dto.Id = t.Id;
            dto.CreatedAt = t.CreatedAt;
            dto.UpdatedAt = t.UpdatedAt;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, TeacherDto dto)
        {
            var t = await _repo.GetByIdAsync(id);
            if (t == null) return false;
            t.TeacherCode = dto.TeacherCode;
            t.Name = dto.Name;
            t.Email = dto.Email;
            t.Password = dto.Password;
            t.SpecializedSubject = dto.SpecializedSubject;
            t.UpdatedAt = DateTime.UtcNow;
            await _repo.UpdateAsync(t);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var t = await _repo.GetByIdAsync(id);
            if (t == null) return false;
            await _repo.DeleteAsync(id);
            return true;
        }
    }
} 