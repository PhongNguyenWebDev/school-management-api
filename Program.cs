using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // Để làm việc với IConfiguration
using Microsoft.Extensions.Hosting; // Để sử dụng env.IsDevelopment()
using SchoolManagementApi.Data; // Namespace của ApplicationDbContext
using SchoolManagementApi.Data.SeedData; // Namespace của DbInitializer

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cấu hình DbContext với SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký các services (nếu bạn có)
// builder.Services.AddScoped<IStudentService, StudentService>();
// builder.Services.AddScoped<IStudentRepository, StudentRepository>();

var app = builder.Build();

// Cấu hình HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting(); // Đảm bảo có UseRouting()

app.MapControllers();

// Seed database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        // Áp dụng migrations (tùy chọn, nên dùng trong production)
        context.Database.Migrate();
        DbInitializer.Initialize(services); // Gọi DbInitializer
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while initializing the database.");
    }
}

app.Run();
