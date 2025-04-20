using SchoolManagementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementApi.Repositories.Interfaces
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAllAsync();
        Task<Subject?> GetByIdAsync(int id);
        Task<Subject> AddAsync(Subject entity);
        Task<Subject?> UpdateAsync(Subject entity);
        Task<bool> DeleteAsync(int id);
    }
} 