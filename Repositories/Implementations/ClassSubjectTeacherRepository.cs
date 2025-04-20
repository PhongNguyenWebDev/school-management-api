using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Data;
using SchoolManagementApi.Models;
using SchoolManagementApi.Repositories.Interfaces;

namespace SchoolManagementApi.Repositories.Implementations
{
    public class ClassSubjectTeacherRepository : IClassSubjectTeacherRepository
    {
        private readonly ApplicationDbContext _context;
        public ClassSubjectTeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClassSubjectTeacher>> GetAllAsync()
        {
            return await _context.ClassSubjectTeachers.ToListAsync();
        }

        public async Task<ClassSubjectTeacher?> GetByIdAsync(int id)
        {
            return await _context.ClassSubjectTeachers.FindAsync(id);
        }

        public async Task<ClassSubjectTeacher> AddAsync(ClassSubjectTeacher entity)
        {
            _context.ClassSubjectTeachers.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<ClassSubjectTeacher?> UpdateAsync(ClassSubjectTeacher entity)
        {
            var existing = await _context.ClassSubjectTeachers.FindAsync(entity.Id);
            if (existing == null) return null;
            existing.ClassId = entity.ClassId;
            existing.SubjectId = entity.SubjectId;
            existing.TeacherId = entity.TeacherId;
            existing.Semester = entity.Semester;
            existing.CreatedAt = entity.CreatedAt;
            existing.UpdatedAt = entity.UpdatedAt;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ClassSubjectTeachers.FindAsync(id);
            if (entity == null) return false;
            _context.ClassSubjectTeachers.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 