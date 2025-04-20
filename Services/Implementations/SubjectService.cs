using SchoolManagementApi.DTOs;
using SchoolManagementApi.Models;
using SchoolManagementApi.Repositories.Interfaces;
using SchoolManagementApi.Services.Interfaces;

namespace SchoolManagementApi.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repo;

        public SubjectService(ISubjectRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<SubjectDto>> GetAllAsync()
        {
            var subjects = await _repo.GetAllAsync();
            return subjects.Select(s => new SubjectDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                SubjectCode = s.SubjectCode,
                Credits = s.Credits,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt
            });
        }

        public async Task<SubjectDto?> GetByIdAsync(int id)
        {
            var s = await _repo.GetByIdAsync(id);
            if (s == null) return null;
            return new SubjectDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                SubjectCode = s.SubjectCode,
                Credits = s.Credits,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt
            };
        }

        public async Task<SubjectDto> AddAsync(SubjectDto dto)
        {
            var s = new Subject
            {
                Name = dto.Name,
                Description = dto.Description,
                SubjectCode = dto.SubjectCode,
                Credits = dto.Credits,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            await _repo.AddAsync(s);
            dto.Id = s.Id;
            dto.CreatedAt = s.CreatedAt;
            dto.UpdatedAt = s.UpdatedAt;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, SubjectDto dto)
        {
            var s = await _repo.GetByIdAsync(id);
            if (s == null) return false;
            s.Name = dto.Name;
            s.Description = dto.Description;
            s.SubjectCode = dto.SubjectCode;
            s.Credits = dto.Credits;
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