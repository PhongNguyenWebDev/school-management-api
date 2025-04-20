using SchoolManagementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementApi.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher?> GetByIdAsync(int id);
        Task<Teacher> AddAsync(Teacher entity);
        Task<Teacher?> UpdateAsync(Teacher entity);
        Task<bool> DeleteAsync(int id);
    }
} 