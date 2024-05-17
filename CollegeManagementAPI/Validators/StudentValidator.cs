using CollegeManagementAPI.Models;
using FluentValidation;
namespace CollegeManagementAPI.Validators
{
    public class StudentValidator: AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(s => s.FirstName)
                .NotEmpty().WithName("Student First Name")
                .Length(2, 50); 

            RuleFor(s => s.LastName)
                .NotEmpty().WithName("Student Last Name")
                .Length(2, 50); 

            RuleFor(s => s.Age)
                .NotEmpty().WithName("Student Age")
                .InclusiveBetween(13, 120).WithName("Student Age"); 

            RuleFor(s => s.RegistrationNumber)
                .NotEmpty().WithName("Student Registration Number")
                .Length(5, 20); 

            RuleFor(s => s.Fee)
                .NotEmpty().WithName("Student Fee")
                .InclusiveBetween(0, float.MaxValue).WithName("Student Fee");

            RuleFor(s => s.PendingFee)
                .NotEmpty().WithName("Student Pending Fee")
                .InclusiveBetween(0, float.MaxValue).WithName("Student Pending Fee"); 

            RuleFor(s => s.Course)
                .NotEmpty().WithName("Student Course")
                .Length(5, 50); 

            // Optional validation for foreign keys (if using them)
            // Assuming TeacherId and OrganizationId are strings representing IDs
            RuleFor(s => s.TeacherId)
                .NotEmpty().WithName("Teacher ID")
                .Length(24, 24); 

            RuleFor(s => s.OrganizationId)
                .NotEmpty().WithName("Organization ID")
                .Length(24, 24); 
        }
    }
}
