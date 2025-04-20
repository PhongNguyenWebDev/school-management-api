using SchoolManagementApi.DTOs;
using SchoolManagementApi.Models;
using SchoolManagementApi.Repositories.Interfaces;
using SchoolManagementApi.Services.Interfaces;

namespace SchoolManagementApi.Services.Implementations
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _repo;

        public GradeService(IGradeRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<GradeDto>> GetAllAsync()
        {
            var grades = await _repo.GetAllAsync();
            return grades.Select(g => new GradeDto
            {
                Id = g.Id,
                StudentId = g.StudentId,
                ClassSubjectTeacherId = g.ClassSubjectTeacherId,
                Score = g.Score,
                GradeType = g.GradeType,
                CreatedAt = g.CreatedAt,
                UpdatedAt = g.UpdatedAt,
                Note = g.Note
            });
        }

        public async Task<GradeDto?> GetByIdAsync(int id)
        {
            var g = await _repo.GetByIdAsync(id);
            if (g == null) return null;
            return new GradeDto
            {
                Id = g.Id,
                StudentId = g.StudentId,
                ClassSubjectTeacherId = g.ClassSubjectTeacherId,
                Score = g.Score,
                GradeType = g.GradeType,
                CreatedAt = g.CreatedAt,
                UpdatedAt = g.UpdatedAt,
                Note = g.Note
            };
        }

        public async Task<GradeDto> AddAsync(GradeDto dto)
        {
            var g = new Grade
            {
                StudentId = dto.StudentId,
                ClassSubjectTeacherId = dto.ClassSubjectTeacherId,
                Score = dto.Score,
                GradeType = dto.GradeType,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Note = dto.Note
            };
            await _repo.AddAsync(g);
            dto.Id = g.Id;
            dto.CreatedAt = g.CreatedAt;
            dto.UpdatedAt = g.UpdatedAt;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, GradeDto dto)
        {
            var g = await _repo.GetByIdAsync(id);
            if (g == null) return false;
            g.StudentId = dto.StudentId;
            g.ClassSubjectTeacherId = dto.ClassSubjectTeacherId;
            g.Score = dto.Score;
            g.GradeType = dto.GradeType;
            g.Note = dto.Note;
            g.UpdatedAt = DateTime.UtcNow;
            await _repo.UpdateAsync(g);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var g = await _repo.GetByIdAsync(id);
            if (g == null) return false;
            await _repo.DeleteAsync(id);
            return true;
        }
    }
} 