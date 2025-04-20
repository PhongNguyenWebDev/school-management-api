using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Data;
using SchoolManagementApi.Models;
using SchoolManagementApi.Repositories.Interfaces;

namespace SchoolManagementApi.Repositories.Implementations
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext _context;
        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<Subject?> GetByIdAsync(int id)
        {
            return await _context.Subjects.FindAsync(id);
        }

        public async Task<Subject> AddAsync(Subject entity)
        {
            _context.Subjects.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Subject?> UpdateAsync(Subject entity)
        {
            var existing = await _context.Subjects.FindAsync(entity.Id);
            if (existing == null) return null;
            existing.Name = entity.Name;
            existing.Description = entity.Description;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Subjects.FindAsync(id);
            if (entity == null) return false;
            _context.Subjects.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 