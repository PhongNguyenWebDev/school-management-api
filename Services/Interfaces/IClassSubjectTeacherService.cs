using SchoolManagementApi.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementApi.Services.Interfaces
{
    public interface IClassSubjectTeacherService
    {
        Task<IEnumerable<ClassSubjectTeacherDto>> GetAllAsync();
        Task<ClassSubjectTeacherDto?> GetByIdAsync(int id);
        Task<ClassSubjectTeacherDto> AddAsync(ClassSubjectTeacherDto dto);
        Task<bool> UpdateAsync(int id, ClassSubjectTeacherDto dto);
        Task<bool> DeleteAsync(int id);
    }
} 