using CollegeManagementAPI.Models;
using CollegeManagementAPI.Services;
using CollegeManagementAPI.Services.Models;
using CollegeManagementAPI.Validators;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DatabaseSettings>(
     builder.Configuration.GetSection("MyDb")
    );

builder.Services.AddTransient<IOrganizationService, OrganizationService>();
builder.Services.AddTransient<IValidator<Organization>, OrganizationValidator>();

builder.Services.AddTransient<ITeacherService, TeacherService>();
builder.Services.AddTransient<IValidator<Teacher>, TeacherValidator>();

builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IValidator<Student>, StudentValidator>();

builder.Services.AddTransient<IParentService, ParentService>();

builder.Services.AddControllers();



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
