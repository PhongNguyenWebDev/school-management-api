using SchoolManagementApi.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementApi.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDto>> GetAllAsync();
        Task<TeacherDto?> GetByIdAsync(int id);
        Task<TeacherDto> AddAsync(TeacherDto dto);
        Task<bool> UpdateAsync(int id, TeacherDto dto);
        Task<bool> DeleteAsync(int id);
    }
} 