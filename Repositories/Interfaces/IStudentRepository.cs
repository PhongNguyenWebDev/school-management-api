using SchoolManagementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementApi.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<Student> AddAsync(Student entity);
        Task<Student?> UpdateAsync(Student entity);
        Task<bool> DeleteAsync(int id);
    }
} 