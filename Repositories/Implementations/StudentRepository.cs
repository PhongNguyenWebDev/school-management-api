using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Data;
using SchoolManagementApi.Models;
using SchoolManagementApi.Repositories.Interfaces;

namespace SchoolManagementApi.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> AddAsync(Student entity)
        {
            _context.Students.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Student?> UpdateAsync(Student entity)
        {
            var existing = await _context.Students.FindAsync(entity.Id);
            if (existing == null) return null;
            existing.StudentCode = entity.StudentCode;
            existing.Name = entity.Name;
            existing.Email = entity.Email;
            existing.Password = entity.Password;
            existing.ClassId = entity.ClassId;
            existing.DateOfBirth = entity.DateOfBirth;
            existing.Gender = entity.Gender;
            existing.CreatedAt = entity.CreatedAt;
            existing.UpdatedAt = entity.UpdatedAt;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Students.FindAsync(id);
            if (entity == null) return false;
            _context.Students.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 