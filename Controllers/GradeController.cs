using Microsoft.AspNetCore.Mvc;
using SchoolManagementApi.Models;
using SchoolManagementApi.DTOs;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Data;
using Microsoft.AspNetCore.Authorization;

namespace SchoolManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GradeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GradeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradeDto>>> GetAll()
        {
            var grades = await _context.Grades
                .Select(g => new GradeDto
                {
                    Id = g.Id,
                    StudentId = g.StudentId,
                    ClassSubjectTeacherId = g.ClassSubjectTeacherId,
                    Score = g.Score,
                    GradeType = g.GradeType,
                    CreatedAt = g.CreatedAt,
                    UpdatedAt = g.UpdatedAt,
                    Note = g.Note
                }).ToListAsync();
            return Ok(grades);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GradeDto>> GetById(int id)
        {
            var g = await _context.Grades.FindAsync(id);
            if (g == null) return NotFound();
            var dto = new GradeDto
            {
                Id = g.Id,
                StudentId = g.StudentId,
                ClassSubjectTeacherId = g.ClassSubjectTeacherId,
                Score = g.Score,
                GradeType = g.GradeType,
                CreatedAt = g.CreatedAt,
                UpdatedAt = g.UpdatedAt,
                Note = g.Note
            };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<GradeDto>> Create(GradeDto dto)
        {
            var g = new Grade
            {
                StudentId = dto.StudentId,
                ClassSubjectTeacherId = dto.ClassSubjectTeacherId,
                Score = dto.Score,
                GradeType = dto.GradeType,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Note = dto.Note
            };
            _context.Grades.Add(g);
            await _context.SaveChangesAsync();
            dto.Id = g.Id;
            dto.CreatedAt = g.CreatedAt;
            dto.UpdatedAt = g.UpdatedAt;
            return CreatedAtAction(nameof(GetById), new { id = g.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GradeDto dto)
        {
            var g = await _context.Grades.FindAsync(id);
            if (g == null) return NotFound();
            g.StudentId = dto.StudentId;
            g.ClassSubjectTeacherId = dto.ClassSubjectTeacherId;
            g.Score = dto.Score;
            g.GradeType = dto.GradeType;
            g.Note = dto.Note;
            g.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var g = await _context.Grades.FindAsync(id);
            if (g == null) return NotFound();
            _context.Grades.Remove(g);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 