using SchoolManagementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementApi.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<Course> AddAsync(Course course);
        Task<Course?> UpdateAsync(Course course);
        Task<bool> DeleteAsync(int id);
    }
} 