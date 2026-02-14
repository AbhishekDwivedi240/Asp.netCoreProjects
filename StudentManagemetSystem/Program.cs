using Microsoft.EntityFrameworkCore;
using StudentManagemetSystem;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("st")));
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();


