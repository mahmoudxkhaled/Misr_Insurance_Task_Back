using Microsoft.EntityFrameworkCore;
using MIT.BL;
using MIT.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



#region Database
builder.Services.AddDbContext<MITDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion

builder.Services.AddBusinessLayer();
builder.Services.AddDataAccessLayer();


















var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
