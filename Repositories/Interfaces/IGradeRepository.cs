using SchoolManagementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementApi.Repositories.Interfaces
{
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> GetAllAsync();
        Task<Grade?> GetByIdAsync(int id);
        Task<Grade> AddAsync(Grade entity);
        Task<Grade?> UpdateAsync(Grade entity);
        Task<bool> DeleteAsync(int id);
    }
} 