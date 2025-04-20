using SchoolManagementApi.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementApi.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDto>> GetAllAsync();
        Task<SubjectDto?> GetByIdAsync(int id);
        Task<SubjectDto> AddAsync(SubjectDto dto);
        Task<bool> UpdateAsync(int id, SubjectDto dto);
        Task<bool> DeleteAsync(int id);
    }
} 