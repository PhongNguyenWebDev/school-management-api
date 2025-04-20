using SchoolManagementApi.DTOs;
using SchoolManagementApi.Models;
using SchoolManagementApi.Repositories.Interfaces;
using SchoolManagementApi.Services.Interfaces;

namespace SchoolManagementApi.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var students = await _repo.GetAllAsync();
            return students.Select(s => new StudentDto
            {
                Id = s.Id,
                StudentCode = s.StudentCode,
                Name = s.Name,
                Email = s.Email,
                Password = s.Password,
                ClassId = s.ClassId,
                DateOfBirth = s.DateOfBirth,
                Gender = s.Gender,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt
            });
        }

        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            var s = await _repo.GetByIdAsync(id);
            if (s == null) return null;
            return new StudentDto
            {
                Id = s.Id,
                StudentCode = s.StudentCode,
                Name = s.Name,
                Email = s.Email,
                Password = s.Password,
                ClassId = s.ClassId,
                DateOfBirth = s.DateOfBirth,
                Gender = s.Gender,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt
            };
        }

        public async Task<StudentDto> AddAsync(StudentDto dto)
        {
            var s = new Student
            {
                StudentCode = dto.StudentCode,
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                ClassId = dto.ClassId,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            await _repo.AddAsync(s);
            dto.Id = s.Id;
            dto.CreatedAt = s.CreatedAt;
            dto.UpdatedAt = s.UpdatedAt;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, StudentDto dto)
        {
            var s = await _repo.GetByIdAsync(id);
            if (s == null) return false;
            s.StudentCode = dto.StudentCode;
            s.Name = dto.Name;
            s.Email = dto.Email;
            s.Password = dto.Password;
            s.ClassId = dto.ClassId;
            s.DateOfBirth = dto.DateOfBirth;
            s.Gender = dto.Gender;
            s.UpdatedAt = DateTime.UtcNow;
            await _repo.UpdateAsync(s);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var s = await _repo.GetByIdAsync(id);
            if (s == null) return false;
            await _repo.DeleteAsync(id);
            return true;
        }
    }
} 