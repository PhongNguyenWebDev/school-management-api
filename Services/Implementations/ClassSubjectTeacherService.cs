using SchoolManagementApi.DTOs;
using SchoolManagementApi.Models;
using SchoolManagementApi.Repositories.Interfaces;
using SchoolManagementApi.Services.Interfaces;

namespace SchoolManagementApi.Services.Implementations
{
    public class ClassSubjectTeacherService : IClassSubjectTeacherService
    {
        private readonly IClassSubjectTeacherRepository _repo;

        public ClassSubjectTeacherService(IClassSubjectTeacherRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ClassSubjectTeacherDto>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            return items.Select(x => new ClassSubjectTeacherDto
            {
                Id = x.Id,
                ClassId = x.ClassId,
                SubjectId = x.SubjectId,
                TeacherId = x.TeacherId,
                Semester = x.Semester,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            });
        }

        public async Task<ClassSubjectTeacherDto?> GetByIdAsync(int id)
        {
            var x = await _repo.GetByIdAsync(id);
            if (x == null) return null;
            return new ClassSubjectTeacherDto
            {
                Id = x.Id,
                ClassId = x.ClassId,
                SubjectId = x.SubjectId,
                TeacherId = x.TeacherId,
                Semester = x.Semester,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            };
        }

        public async Task<ClassSubjectTeacherDto> AddAsync(ClassSubjectTeacherDto dto)
        {
            var x = new ClassSubjectTeacher
            {
                ClassId = dto.ClassId,
                SubjectId = dto.SubjectId,
                TeacherId = dto.TeacherId,
                Semester = dto.Semester,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            await _repo.AddAsync(x);
            dto.Id = x.Id;
            dto.CreatedAt = x.CreatedAt;
            dto.UpdatedAt = x.UpdatedAt;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, ClassSubjectTeacherDto dto)
        {
            var x = await _repo.GetByIdAsync(id);
            if (x == null) return false;
            x.ClassId = dto.ClassId;
            x.SubjectId = dto.SubjectId;
            x.TeacherId = dto.TeacherId;
            x.Semester = dto.Semester;
            x.UpdatedAt = DateTime.UtcNow;
            await _repo.UpdateAsync(x);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var x = await _repo.GetByIdAsync(id);
            if (x == null) return false;
            await _repo.DeleteAsync(id);
            return true;
        }
    }
} 