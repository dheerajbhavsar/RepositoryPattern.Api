using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Api.Core;
using RepositoryPattern.Api.Core.Repositories;
using RepositoryPattern.Api.DbContexts;
using RepositoryPattern.Api.Persistence;
using RepositoryPattern.Api.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var config = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContext, PlutoContext>(opt => opt.UseSqlite(config.GetConnectionString("PlutoContext")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
