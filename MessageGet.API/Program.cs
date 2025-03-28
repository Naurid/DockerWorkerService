using MessageGet.API;
using MessageGet.API.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<GetContext>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("default")));
builder.Services.AddHostedService<CheckService>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
