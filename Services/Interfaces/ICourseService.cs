using SchoolManagementApi.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementApi.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllAsync();
        Task<CourseDto?> GetByIdAsync(int id);
        Task<CourseDto> AddAsync(CourseDto dto);
        Task<bool> UpdateAsync(int id, CourseDto dto);
        Task<bool> DeleteAsync(int id);
    }
} 