using CollegeManagementAPI.Models;
using CollegeManagementAPI.Services;
using CollegeManagementAPI.Services.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DatabaseSettings>(
     builder.Configuration.GetSection("MyDb")
    );

builder.Services.AddTransient<IOrganizationService, OrganizationService>();
builder.Services.AddTransient<ITeacherService, TeacherService>();
builder.Services.AddTransient<IStudentService, StudentService>();



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
