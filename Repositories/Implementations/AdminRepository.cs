using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Data;
using SchoolManagementApi.Models;
using SchoolManagementApi.Repositories.Interfaces;

namespace SchoolManagementApi.Repositories.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;
        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<Admin?> GetByIdAsync(int id)
        {
            return await _context.Admins.FindAsync(id);
        }

        public async Task<Admin> AddAsync(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        public async Task<Admin?> UpdateAsync(Admin admin)
        {
            var existing = await _context.Admins.FindAsync(admin.Id);
            if (existing == null) return null;
            existing.Username = admin.Username;
            existing.PasswordHash = admin.PasswordHash;
            existing.Email = admin.Email;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null) return false;
            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 