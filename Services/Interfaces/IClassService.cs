using SchoolManagementApi.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementApi.Services.Interfaces
{
    public interface IClassService
    {
        Task<IEnumerable<ClassDto>> GetAllAsync();
        Task<ClassDto?> GetByIdAsync(int id);
        Task<ClassDto> AddAsync(ClassDto dto);
        Task<bool> UpdateAsync(int id, ClassDto dto);
        Task<bool> DeleteAsync(int id);
    }
} 