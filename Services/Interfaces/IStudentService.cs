using SchoolManagementApi.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementApi.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<StudentDto?> GetByIdAsync(int id);
        Task<StudentDto> AddAsync(StudentDto dto);
        Task<bool> UpdateAsync(int id, StudentDto dto);
        Task<bool> DeleteAsync(int id);
    }
} 