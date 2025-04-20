using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Data;
using SchoolManagementApi.Models;
using SchoolManagementApi.Repositories.Interfaces;

namespace SchoolManagementApi.Repositories.Implementations
{
    public class ClassRepository : IClassRepository
    {
        private readonly ApplicationDbContext _context;
        public ClassRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Class>> GetAllAsync()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Class?> GetByIdAsync(int id)
        {
            return await _context.Classes.FindAsync(id);
        }

        public async Task<Class> AddAsync(Class entity)
        {
            _context.Classes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Class?> UpdateAsync(Class entity)
        {
            var existing = await _context.Classes.FindAsync(entity.Id);
            if (existing == null) return null;
            existing.Name = entity.Name;
            existing.CourseId = entity.CourseId;
            existing.CreatedAt = entity.CreatedAt;
            existing.UpdatedAt = entity.UpdatedAt;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Classes.FindAsync(id);
            if (entity == null) return false;
            _context.Classes.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 