using MessagePost.API.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<PostContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("default")));

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
