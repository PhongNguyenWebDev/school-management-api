using SchoolManagementApi.DTOs;
using SchoolManagementApi.Models;
using SchoolManagementApi.Repositories.Interfaces;
using SchoolManagementApi.Services.Interfaces;

namespace SchoolManagementApi.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repo;

        public AdminService(IAdminRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<AdminDto>> GetAllAsync()
        {
            var admins = await _repo.GetAllAsync();
            return admins.Select(a => new AdminDto
            {
                Id = a.Id,
                Name = a.Name,
                Email = a.Email,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt
            });
        }

        public async Task<AdminDto?> GetByIdAsync(int id)
        {
            var a = await _repo.GetByIdAsync(id);
            if (a == null) return null;
            return new AdminDto
            {
                Id = a.Id,
                Name = a.Name,
                Email = a.Email,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt
            };
        }

        public async Task<AdminDto> AddAsync(AdminDto dto)
        {
            var admin = new Admin
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = "", // Xử lý password ở nơi khác nếu cần
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            await _repo.AddAsync(admin);
            dto.Id = admin.Id;
            dto.CreatedAt = admin.CreatedAt;
            dto.UpdatedAt = admin.UpdatedAt;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, AdminDto dto)
        {
            var admin = await _repo.GetByIdAsync(id);
            if (admin == null) return false;
            admin.Name = dto.Name;
            admin.Email = dto.Email;
            admin.UpdatedAt = DateTime.UtcNow;
            await _repo.UpdateAsync(admin);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var admin = await _repo.GetByIdAsync(id);
            if (admin == null) return false;
            await _repo.DeleteAsync(id);
            return true;
        }
    }
} 