using Microsoft.AspNetCore.Mvc;
using SchoolManagementApi.Models;
using SchoolManagementApi.DTOs;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Data;

namespace SchoolManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassSubjectTeacherController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClassSubjectTeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassSubjectTeacherDto>>> GetAll()
        {
            var items = await _context.ClassSubjectTeachers
                .Select(x => new ClassSubjectTeacherDto
                {
                    Id = x.Id,
                    ClassId = x.ClassId,
                    SubjectId = x.SubjectId,
                    TeacherId = x.TeacherId,
                    Semester = x.Semester,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                }).ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassSubjectTeacherDto>> GetById(int id)
        {
            var x = await _context.ClassSubjectTeachers.FindAsync(id);
            if (x == null) return NotFound();
            var dto = new ClassSubjectTeacherDto
            {
                Id = x.Id,
                ClassId = x.ClassId,
                SubjectId = x.SubjectId,
                TeacherId = x.TeacherId,
                Semester = x.Semester,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<ClassSubjectTeacherDto>> Create(ClassSubjectTeacherDto dto)
        {
            var x = new ClassSubjectTeacher
            {
                ClassId = dto.ClassId,
                SubjectId = dto.SubjectId,
                TeacherId = dto.TeacherId,
                Semester = dto.Semester,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _context.ClassSubjectTeachers.Add(x);
            await _context.SaveChangesAsync();
            dto.Id = x.Id;
            dto.CreatedAt = x.CreatedAt;
            dto.UpdatedAt = x.UpdatedAt;
            return CreatedAtAction(nameof(GetById), new { id = x.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClassSubjectTeacherDto dto)
        {
            var x = await _context.ClassSubjectTeachers.FindAsync(id);
            if (x == null) return NotFound();
            x.ClassId = dto.ClassId;
            x.SubjectId = dto.SubjectId;
            x.TeacherId = dto.TeacherId;
            x.Semester = dto.Semester;
            x.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var x = await _context.ClassSubjectTeachers.FindAsync(id);
            if (x == null) return NotFound();
            _context.ClassSubjectTeachers.Remove(x);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 