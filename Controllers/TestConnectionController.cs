using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration; // Đảm bảo thêm namespace này

[ApiController]
[Route("api/test")]
public class TestConnectionController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public TestConnectionController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("connect")]
    public IActionResult TestDatabaseConnection()
    {
        string? connectionString = _configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            return StatusCode(500, "Không tìm thấy cấu hình chuỗi kết nối 'DefaultConnection'. Vui lòng kiểm tra file appsettings.json.");
        }

        try
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    return Ok("Kết nối đến database thành công!");
                }
                else
                {
                    return StatusCode(500, "Không thể mở kết nối đến database.");
                }
            }
        }
        catch (SqlException ex)
        {
            return StatusCode(500, $"Lỗi kết nối SQL Server: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Lỗi không xác định khi cố gắng kết nối: {ex.Message}");
        }
    }
}