using SchoolManagementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementApi.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Admin>> GetAllAsync();
        Task<Admin?> GetByIdAsync(int id);
        Task<Admin> AddAsync(Admin admin);
        Task<Admin?> UpdateAsync(Admin admin);
        Task<bool> DeleteAsync(int id);
    }
} 