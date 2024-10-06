using Microsoft.EntityFrameworkCore;
using StudentsMustHaveServer.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StudentsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.Run();