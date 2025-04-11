using EFCore.Mapping;
using EFCore.Models.Data;
using EFCore.Repositories;
using EFCore.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IDepartmentsService, DepartmentsService>();
builder.Services.AddScoped<DepartmentsRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ProjectsRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository,EmployeesRepository>();
builder.Services.AddScoped<ISalariesService, SalariesService>();    
builder.Services.AddScoped<SalariesRepository>();
builder.Services.AddScoped<IProjectEmployeeService, ProjectEmployeeService>();
builder.Services.AddScoped<IProjectEmployeeRepository,ProjectEmployeeRepository>();


var app = builder.Build();
DataSeeder.SeedDepartment(app.Services);

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
