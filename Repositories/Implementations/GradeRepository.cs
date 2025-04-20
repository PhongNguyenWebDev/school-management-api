using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Data;
using SchoolManagementApi.Models;
using SchoolManagementApi.Repositories.Interfaces;

namespace SchoolManagementApi.Repositories.Implementations
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ApplicationDbContext _context;
        public GradeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Grade>> GetAllAsync()
        {
            return await _context.Grades.ToListAsync();
        }

        public async Task<Grade?> GetByIdAsync(int id)
        {
            return await _context.Grades.FindAsync(id);
        }

        public async Task<Grade> AddAsync(Grade entity)
        {
            _context.Grades.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Grade?> UpdateAsync(Grade entity)
        {
            var existing = await _context.Grades.FindAsync(entity.Id);
            if (existing == null) return null;
            existing.StudentId = entity.StudentId;
            existing.ClassSubjectTeacherId = entity.ClassSubjectTeacherId;
            existing.Score = entity.Score;
            existing.Note = entity.Note;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Grades.FindAsync(id);
            if (entity == null) return false;
            _context.Grades.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 