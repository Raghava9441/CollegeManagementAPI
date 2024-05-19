using CollegeManagementAPI.Models;
using CollegeManagementAPI.Services;
using CollegeManagementAPI.Services.Models;
using CollegeManagementAPI.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure JWT Authentication
var key = Encoding.ASCII.GetBytes("YourSecretKeyHere");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

//Authorization Policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
    options.AddPolicy("TeacherPolicy", policy => policy.RequireRole("Teacher"));
    options.AddPolicy("StudentPolicy", policy => policy.RequireRole("Student"));
    options.AddPolicy("ParentPolicy", policy => policy.RequireRole("Parent"));
});

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
builder.Services.AddTransient<IUserService, Userservice>();


builder.Services.AddControllers();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
