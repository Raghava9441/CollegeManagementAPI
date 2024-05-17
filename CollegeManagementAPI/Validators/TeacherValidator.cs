using CollegeManagementAPI.Models;
using FluentValidation;

namespace CollegeManagementAPI.Validators
{
    public class TeacherValidator: AbstractValidator<Teacher>
    {
        public TeacherValidator()
        {

            RuleFor(o => o.FirtName)
                .NotEmpty().NotNull().WithName("Teacher First Name")
                .Length(2, 255);

            RuleFor(o => o.lastname)
                .NotEmpty().NotNull().WithName("Teacher Category")
                .Length(2, 50);

            RuleFor(o => o.Email)
                .NotEmpty().NotNull().WithName("Teacher Email")
                .Length(5, 255);

            RuleFor(o => o.Experience)
            .NotEmpty().NotNull().WithName("Teacher Experience");

            RuleFor(o => o.OrganizationId)
            .NotEmpty().NotNull().WithName("Teacher OrganizationId");

            RuleFor(o => o.Subject)
            .NotEmpty().NotNull().WithName("Teacher Subject");

            RuleFor(o => o.Age)
            .NotEmpty().NotNull().WithName("Teacher Age");

            RuleFor(o => o.PhoneNumber)
            .NotEmpty().NotNull().WithName("Teacher PhoneNumber");
        }
    }
}
