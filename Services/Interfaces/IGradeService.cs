using SchoolManagementApi.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementApi.Services.Interfaces
{
    public interface IGradeService
    {
        Task<IEnumerable<GradeDto>> GetAllAsync();
        Task<GradeDto?> GetByIdAsync(int id);
        Task<GradeDto> AddAsync(GradeDto dto);
        Task<bool> UpdateAsync(int id, GradeDto dto);
        Task<bool> DeleteAsync(int id);
    }
} 