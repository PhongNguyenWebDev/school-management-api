using SchoolManagementApi.Models;

namespace SchoolManagementApi.Repositories.Interfaces
{
    public interface IClassSubjectTeacherRepository
    {
        // Thêm các phương thức CRUD cơ bản
        Task<IEnumerable<ClassSubjectTeacher>> GetAllAsync();
        Task<ClassSubjectTeacher?> GetByIdAsync(int id);
        Task<ClassSubjectTeacher> AddAsync(ClassSubjectTeacher entity);
        Task<ClassSubjectTeacher?> UpdateAsync(ClassSubjectTeacher entity);
        Task<bool> DeleteAsync(int id);
    }
} 