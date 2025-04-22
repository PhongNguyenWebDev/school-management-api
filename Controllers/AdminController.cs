using Microsoft.AspNetCore.Mvc;
using SchoolManagementApi.DTOs;
using SchoolManagementApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;
        private readonly IConfiguration _configuration;

        public AdminController(IAdminService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminDto>>> GetAll()
        {
            var admins = await _service.GetAllAsync();
            return Ok(admins);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminDto>> GetById(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<AdminDto>> Create(AdminDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AdminDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AdminLoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 👈 để debug xem chính xác field nào gây lỗi
            }
            // Demo: xác thực đơn giản, bạn nên thay bằng kiểm tra DB thực tế
            if (loginDto.Username == "admin" && loginDto.Password == "admin123")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, loginDto.Username),
                    new Claim(ClaimTypes.Role, "Admin")
                };
                var jwtSettings = _configuration.GetSection("JwtSettings");
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: jwtSettings["Issuer"],
                    audience: jwtSettings["Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(int.Parse(jwtSettings["ExpiryMinutes"]!)),
                    signingCredentials: creds
                );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return Unauthorized();
        }
    }
} 