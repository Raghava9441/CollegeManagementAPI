using CollegeManagementAPI.Models;
using FluentValidation;

namespace CollegeManagementAPI.Validators
{
        public class OrganizationValidator : AbstractValidator<Organization>
        {
            public OrganizationValidator()
            {

                RuleFor(o => o.Name)
                    .NotEmpty().WithName("Organization Name")
                    .Length(2, 255);

                RuleFor(o => o.Category)
                    .NotEmpty().WithName("Organization Category")
                    .Length(2, 50);

                RuleFor(o => o.Address)
                    .NotEmpty().WithName("Organization Address")
                    .Length(5, 255);

                RuleFor(o => o.Number)
                .NotEmpty().WithName("Organization Number");

            }
        }
}
