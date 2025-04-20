using SchoolManagementApi.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementApi.Services.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<AdminDto>> GetAllAsync();
        Task<AdminDto?> GetByIdAsync(int id);
        Task<AdminDto> AddAsync(AdminDto dto);
        Task<bool> UpdateAsync(int id, AdminDto dto);
        Task<bool> DeleteAsync(int id);
    }
} 