using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Data;
using SchoolManagementApi.Models;
using SchoolManagementApi.Repositories.Interfaces;

namespace SchoolManagementApi.Repositories.Implementations
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;
        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher?> GetByIdAsync(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<Teacher> AddAsync(Teacher entity)
        {
            _context.Teachers.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Teacher?> UpdateAsync(Teacher entity)
        {
            var existing = await _context.Teachers.FindAsync(entity.Id);
            if (existing == null) return null;
            existing.TeacherCode = entity.TeacherCode;
            existing.Name = entity.Name;
            existing.Email = entity.Email;
            existing.Password = entity.Password;
            existing.SpecializedSubject = entity.SpecializedSubject;
            existing.CreatedAt = entity.CreatedAt;
            existing.UpdatedAt = entity.UpdatedAt;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Teachers.FindAsync(id);
            if (entity == null) return false;
            _context.Teachers.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 